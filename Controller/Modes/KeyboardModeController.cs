using kanavrt.Model;
using System.Text;

namespace kanavrt.Controller.Modes {
	public class KeyboardModeController(KanaModel model) : AbstractModeController(model, 1) {
		public StringBuilder PartialGuess { get; set; } = new();

		public bool IsPartialWrapper(string latin) {
			if (isError) throw new("Can't call function if controller Error.");

			return IsPartial(latin);
		}

		protected bool IsPartial(string latin) {
			string[] latinForms = Model.lookup[CorrectSyllable].Latin;

			foreach (string latinForm in latinForms) {
				if (latinForm.StartsWith(latin)) { 
					return true; 
				}
			}

			return false;
		}

		protected override void Update(string syllable) {
			PartialGuess.Append(syllable);
			string partial = PartialGuess.ToString();

			if (IsPartial(partial) == IsCorrect(partial)) {
				if (IsCorrect(partial)) { 
					Model.lookup[CorrectSyllable].Corrects++;
					CorrectGuesses++;
				} else { 
					Model.lookup[CorrectSyllable].Wrongs++;
					WrongGuesses++;
				}

				PartialGuess.Clear();
				NextMove();
			} 
		}
	}
}
