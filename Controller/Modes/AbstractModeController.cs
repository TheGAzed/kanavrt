using kanavrt.Model;
using System;

namespace kanavrt.Controller.Modes {
	public abstract class AbstractModeController {
		/// <summary>
		/// Minimum number of guesses based on mode.
		/// </summary>
		public int GuessCount { get; } = 1;
		/// <summary>
		/// The correct syllable during current move.
		/// </summary>
		public string CorrectSyllable { get; set; } = string.Empty;
		/// <summary>
		/// Character model to get random characters from.
		/// </summary>
		protected KanaModel Model { get; }
		/// <summary>
		/// Class to generate random indexes to get syllables.
		/// </summary>
		protected Random random = new Random();

		public int WrongGuesses { get; set; } = 0;
		public int CorrectGuesses { get; set; } = 0;

		public AbstractModeController(KanaModel model, int guessCount) {
			if (0 == guessCount) { // guess count must be greater than 0
				throw new Exception("[ERROR01] 'guessCount' parameter can't be zero.");
			}

			GuessCount = guessCount;

			if (guessCount > model.characters.Count) { // model must have at least guessCount characters to work properly
				throw new Exception("[ERROR02] Available character count is less than " + guessCount + '.');
			}

			Model = model;

			InitialMove();
		}

		/// <summary>
		/// Initial move thet gets called by the contructor.
		/// </summary>
		protected virtual void InitialMove() {
			int index = random.Next(0, Model.characters.Count);
			CorrectSyllable = Model.characters.ElementAt(index);
		}

		/// <summary>
		/// Next move that gets called by update after the user succedes/fails at guessing the correct character.
		/// </summary>
		protected virtual void NextMove() {
			if (1 == Model.characters.Count) return;

			Model.characters.Remove(CorrectSyllable);

			int index = random.Next(0, Model.characters.Count);

			string temp = Model.characters.ElementAt(index);
			Model.characters.Add(CorrectSyllable);
			CorrectSyllable = temp;
		}

		/// <summary>
		/// Updates the necesarry mode variables and calls NextMove.
		/// </summary>
		/// <param name="syllable"></param>
		public virtual void Update(string syllable) {
			if (CorrectSyllable.Equals(syllable)) {
				CorrectGuesses++;
				Model.lookup[CorrectSyllable].Corrects++; 
			} 
			else {
				WrongGuesses++;
				Model.lookup[CorrectSyllable].Wrongs++; 
			}

			NextMove();
		}

		/// <summary>
		/// Checks if current latin syllable is correct.
		/// </summary>
		/// <param name="latin">String syllable to check.</param>
		/// <returns>true, if latin syllable is correct, false otherwise</returns>
		public bool IsCorrect(string latin) {
			string[] latinForms = Model.lookup[CorrectSyllable].Latin;
			return latinForms.Contains(latin);
		}

		public virtual void Reset() {
			WrongGuesses = 0;
			CorrectGuesses = 0;
		}
	}
}
