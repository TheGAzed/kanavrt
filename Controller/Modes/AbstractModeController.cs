using kanavrt.Model;
using kanavrt.Model.Statistics;
using kanavrt.Model.Settings;
using System;

namespace kanavrt.Controller.Modes {
	public class ControllerError(string errorMessage, string errorSolution, int errorValue) {
		public string Message = errorMessage;
		public string Solution = errorSolution;
		public int Value = errorValue;
	}

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
		/// Character kanaModel to get random characters from.
		/// </summary>
		protected KanaModel kanaModel { get; }
		protected StatisticsModel statisticsModel { get; }
		protected SettingsModel settingsModel { get; }
		/// <summary>
		/// Class to generate random indexes to get syllables.
		/// </summary>
		protected Random random = new Random();
		public bool isError = false;
		public ControllerError Error;

		public int WrongGuesses { get; set; } = 0;
		public int CorrectGuesses { get; set; } = 0;

		public AbstractModeController(KanaModel kanaModel, StatisticsModel statisticsModel, SettingsModel settingsModel, int guessCount) {
			GuessCount = guessCount;
			this.kanaModel = kanaModel;
			this.statisticsModel = statisticsModel;
			this.settingsModel = settingsModel;

			if (0 == guessCount) { // guess count must be greater than 0
				throw new Exception("[ERROR01] 'guessCount' parameter can't be zero.");
			}

			if (guessCount > settingsModel.characters.Count) { // kanaModel must have at least guessCount characters to work properly
				isError = true;
				Error = new("Available syllable count is less than " + guessCount + '.', "Increase syllable count in settings to " + guessCount + " or more.", 1);
				return;
			}

			Error = new("No errors found", "No solution required", 0);

			InitialMoveWrapped();
		}

		protected void InitialMoveWrapped() {
			if (isError) throw new("Can't call function if controller Error.");
			InitialMove();
		}
		/// <summary>
		/// Initial move thet gets called by the contructor.
		/// </summary>
		protected virtual void InitialMove() {
			int index = random.Next(0, settingsModel.characters.Count);
			CorrectSyllable = settingsModel.characters.ElementAt(index);
		}

		protected void NextMoveWrapper() {
			if (isError) throw new("Can't call function if controller Error.");
			NextMove();
		}

		/// <summary>
		/// Next move that gets called by update after the user succedes/fails at guessing the correct character.
		/// </summary>
		protected virtual void NextMove() {
			if (1 == settingsModel.characters.Count) return;

			settingsModel.characters.Remove(CorrectSyllable);

			int index = random.Next(0, settingsModel.characters.Count);

			string temp = settingsModel.characters.ElementAt(index);
			settingsModel.characters.Add(CorrectSyllable);
			CorrectSyllable = temp;
		}

		public void UpdateWrapper(string syllable) {
			if (isError) throw new("Can't call function if controller Error.");
			Update(syllable);
		}

		/// <summary>
		/// Updates the necesarry mode variables and calls NextMove.
		/// </summary>
		/// <param name="syllable"></param>
		protected virtual void Update(string syllable) {
			if (CorrectSyllable.Equals(syllable)) {
				CorrectGuesses++;
				statisticsModel.lookup[CorrectSyllable].Corrects++; 
			} 
			else {
				WrongGuesses++;
				statisticsModel.lookup[CorrectSyllable].Wrongs++; 
			}

			NextMove();
		}

		public bool IsCorrectWrapper(string latin) {
			if (isError) throw new("Can't call function if controller Error.");

			return IsCorrect(latin);
		}

		/// <summary>
		/// Checks if current latin syllable is correct.
		/// </summary>
		/// <param name="latin">String syllable to check.</param>
		/// <returns>true, if latin syllable is correct, false otherwise</returns>
		protected virtual bool IsCorrect(string latin) {
			string[] latinForms = kanaModel.lookup[CorrectSyllable].Latin;
			return latinForms.Contains(latin);
		}

		public void ResetWrapper() {
			if (isError) throw new("Can't call function if controller Error.");

			Reset();
		}

		public virtual void Reset() {
			WrongGuesses = 0;
			CorrectGuesses = 0;
			NextMove();
		}
	}
}
