using kanavrt.Model;
using kanavrt.Model.Statistics;
using kanavrt.Model.Settings;

namespace kanavrt.Controller.Quiz {
	/// <summary>
	/// EitherOrController is a quiz controller that handles the either/or quiz mode for kana characters.
	/// </summary>
	/// <param name="kanaModel">Model to lookup kana information.</param>
	/// <param name="statisticsModel">Model to look up count of wrong and correct guesses for each playable kana.</param>
	/// <param name="settingsModel">Model to look up current playable kana set.</param>
	public class EitherOrController(KanaModel kanaModel, StatisticsModel statisticsModel, SettingsModel settingsModel) : AbstractQuizController(kanaModel, statisticsModel, settingsModel, 2) {
        public string WrongSyllable { get; set; } = string.Empty;

        protected override void InitialMove_() {
			// select random wrong and correct syllable from settingsModel and remove it from the set
			int index = random.Next(0, settingsModel.characters.Count); // get random index
			CorrectSyllable = settingsModel.characters.ElementAt(index); // get kana at random index for CorrectSyllable
			settingsModel.characters.Remove(CorrectSyllable); // remove it to prevent duplicates in WrongSyllable

			index = random.Next(0, settingsModel.characters.Count); // get another random index
			WrongSyllable = settingsModel.characters.ElementAt(index); // get kana at random index for WrongSyllable

			settingsModel.characters.Add(CorrectSyllable); // re-add CorrectSyllable to the set
		}

        protected override void NextMove_() {
            if (settingsModel.characters.Count == GuessCount) { // if there are only 2 characters in the set
				InitialMove(); // pick two new random syllables
			} else {
                string temp = CorrectSyllable; // save the CorrectSyllable as temporary
				settingsModel.characters.Remove(CorrectSyllable); // remove it from the set to prevent guessing twice

				InitialMove(); // pick two new random syllables

				settingsModel.characters.Add(temp); // re-add the CorrectSyllable back to the set
			}
        }

		protected override void Update_(string input) {
			if (CorrectSyllable.Equals(input)) { // if the input is correct
				CorrectGuesses++; // increment correct quiz guesses
				statisticsModel.lookup[CorrectSyllable].Corrects++; // increment correct count in for kana in statistics
			} else {
				WrongGuesses++; // increment wrong quiz guesses
				statisticsModel.lookup[CorrectSyllable].Wrongs++; // increment wrong count in for kana in statistics
			}

			NextMove(); // pick two new random syllables
		}

		protected override bool IsCorrect_(string latin) {
			string[] latinForms = kanaModel.lookup[CorrectSyllable].Latin; // save the latin forms of the syllable
			return latinForms.Contains(latin); // check if array of latin forms contains the input as correct kana
		}

		protected override void Reset_() {
			WrongGuesses = 0;
			CorrectGuesses = 0;
			NextMove();
		}
	}
}
