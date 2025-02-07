using kanavrt.Model;

namespace kanavrt.Controller.Modes {
    public class EitherOrModeController(KanaModel model) : AbstractModeController(model, 2) {
        public string WrongSyllable { get; set; } = string.Empty;

        protected override void InitialMove() {
            base.InitialMove();

            int index = random.Next(0, Model.characters.Count);
            CorrectSyllable = Model.characters.ElementAt(index);
            Model.characters.Remove(CorrectSyllable);

            index = random.Next(0, Model.characters.Count);
            WrongSyllable = Model.characters.ElementAt(index);

            Model.characters.Add(CorrectSyllable);
        }

        protected override void NextMove() {
            if (Model.characters.Count == GuessCount) {
                InitialMove();
            } else {
                string temp = CorrectSyllable;
                Model.characters.Remove(CorrectSyllable);

                InitialMove();

                Model.characters.Add(temp);
            }
        }
    }
}
