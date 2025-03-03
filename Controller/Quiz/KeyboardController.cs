using kanavrt.Model;
using kanavrt.Model.Settings;
using kanavrt.Model.Statistics;
using System.Text;

namespace kanavrt.Controller.Quiz {
	public class KeyboardController(KanaModel kanaModel, StatisticsModel statisticsModel, SettingsModel settingsModel) : AbstractQuizController(kanaModel, statisticsModel, settingsModel, 1) {
		public StringBuilder PartialGuess { get; set; } = new();

		public bool IsPartial(string latin) {
			if (isError) throw new("Can't call function if controller Error.");

			return IsPartial_(latin);
		}

		protected bool IsPartial_(string latin) {
			string[] latinForms = kanaModel.lookup[CorrectSyllable].Latin;

			foreach (string latinForm in latinForms) {
				if (latinForm.StartsWith(latin)) { 
					return true; 
				}
			}

			return false;
		}

		protected override void Update_(string input) {
			PartialGuess.Append(input);
			string partial = PartialGuess.ToString();

			if (IsPartial_(partial) == IsCorrect_(partial)) {
				if (IsCorrect_(partial)) { 
					statisticsModel.lookup[CorrectSyllable].Corrects++;
					CorrectGuesses++;
				} else { 
					statisticsModel.lookup[CorrectSyllable].Wrongs++;
					WrongGuesses++;
				}

				PartialGuess.Clear();
				NextMove_();
			} 
		}
	}
}
