using kanavrt.Model;
using kanavrt.Model.Statistics;
using kanavrt.Model.Settings;
using System;

namespace kanavrt.Controller.Quiz {
	public class ControllerError(string errorMessage, string errorSolution, int errorValue) {
		public string Message = errorMessage;
		public string Solution = errorSolution;
		public int Value = errorValue;
	}

	public abstract class AbstractQuizController {
		/// <summary>
		/// Minimum number of guesses based on mode.
		/// </summary>
		public int GuessCount { get; } = 1;
		/// <summary>
		/// The correct input during current move.
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

		public AbstractQuizController(KanaModel kanaModel, StatisticsModel statisticsModel, SettingsModel settingsModel, int guessCount) {
			GuessCount = guessCount;
			this.kanaModel = kanaModel;
			this.statisticsModel = statisticsModel;
			this.settingsModel = settingsModel;

			if (0 == guessCount) { // guess count must be greater than 0
				throw new Exception("[ERROR01] 'guessCount' parameter can't be zero.");
			}

			if (guessCount > settingsModel.characters.Count) { // kanaModel must have at least guessCount characters to work properly
				isError = true;
				Error = new("Available input count is less than " + guessCount + '.', "Increase input count in settings to " + guessCount + " or more.", 1);
				return;
			}

			Error = new("No errors found", "No solution required", 0);

			InitialMove();
		}

		protected void InitialMove() {
			if (isError) throw new("Can't call function if controller Error.");
			InitialMove_();
		}

		protected void NextMove() {
			if (isError) throw new("Can't call function if controller Error.");
			NextMove_();
		}

		public void Update(string input) {
			if (isError) throw new("Can't call function if controller Error.");
			Update_(input);
		}

		public bool IsCorrect(string latin) {
			if (isError) throw new("Can't call function if controller Error.");

			return IsCorrect_(latin);
		}

		public void Reset() {
			if (isError) throw new("Can't call function if controller Error.");

			Reset_();
		}

		/// <summary>
		/// Initial move thet gets called by the contructor.
		/// </summary>
		protected abstract void InitialMove_();

		/// <summary>
		/// Next move that gets called by update after the user succedes/fails at guessing the correct character.
		/// </summary>
		protected abstract void NextMove_();

		/// <summary>
		/// Updates the necesarry mode variables and calls NextMove_.
		/// </summary>
		/// <param name="input"></param>
		protected abstract void Update_(string input);

		/// <summary>
		/// Checks if current latin input is correct.
		/// </summary>
		/// <param name="latin">String input to check.</param>
		/// <returns>true, if latin input is correct, false otherwise</returns>
		/// 
		protected abstract bool IsCorrect_(string latin);

		protected abstract void Reset_();
	}
}
