using kanavrt.Model;
using kanavrt.Model.Settings;
using kanavrt.Model.Statistics;
using System.Text;

namespace kanavrt.Controller.Quiz {
	/// <summary>
	/// KeyboardController is a quiz controller that handles the keyboard input for kana characters.
	/// </summary>
	/// <param name="kanaModel">Model to lookup kana information.</param>
	/// <param name="statisticsModel">Model to look up count of wrong and correct guesses for each playable kana.</param>
	/// <param name="settingsModel">Model to look up current playable kana set.</param>
	public class KeyboardController(KanaModel kanaModel, StatisticsModel statisticsModel, SettingsModel settingsModel) : AbstractQuizController(kanaModel, statisticsModel, settingsModel, 1) {
		/// <summary>
		/// The partial latin form of keys pressed by the user, which gets checked against the correct latin kana.
		/// </summary>
		public StringBuilder PartialGuess { get; set; } = new();

		protected override void InitialMove_() {
			int index = random.Next(0, settingsModel.characters.Count); // get random index
			CorrectSyllable = settingsModel.characters.ElementAt(index); // get kana at random index for CorrectSyllable
		}

		protected override void NextMove_() {
			if (1 == settingsModel.characters.Count) return; // if there is only one character in the set, do nothing, since it is allowed

			settingsModel.characters.Remove(CorrectSyllable); // remove CorrectSyllable from the set to prevent guessing twice

			int index = random.Next(0, settingsModel.characters.Count); // get random index

			string temp = settingsModel.characters.ElementAt(index); // save the CorrectSyllable as temporary
			settingsModel.characters.Add(CorrectSyllable); // re-add CorrectSyllable to the set
			CorrectSyllable = temp; // change CorrectSyllable to the new one
		}

		protected override void Update_(string input) {
			PartialGuess.Append(input); // append the input character to the PartialGuess string
			string partial = PartialGuess.ToString(); // turn the StringBuilder into a string

			if (IsPartial(partial) == IsCorrect(partial)) { // if they are equal then the state must change, else it's only partially correct
				if (IsCorrect_(partial)) { // if the input is actually correct
					statisticsModel.lookup[CorrectSyllable].Corrects++;
					CorrectGuesses++;
				} else { // else the input is wrong
					statisticsModel.lookup[CorrectSyllable].Wrongs++;
					WrongGuesses++;
				}

				PartialGuess.Clear(); // clear the PartialGuess StringBuilder
				NextMove(); // update 
			} 
		}

		protected override void Reset_() {
			WrongGuesses = 0;
			CorrectGuesses = 0;
			NextMove();
		}

		protected override bool IsCorrect_(string latin) {
			string[] latinForms = kanaModel.lookup[CorrectSyllable].Latin;
			return latinForms.Contains(latin);
		}
		/// <summary>
		/// Checks if the current latin input partially matches the correct one.
		/// </summary>
		/// <param name="latin">Input string to match.</param>
		/// <returns></returns>
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
	}
}
