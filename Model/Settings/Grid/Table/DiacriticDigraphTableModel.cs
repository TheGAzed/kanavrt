
namespace kanavrt.Model.Settings.Grid.Table {
	public class DiacriticDigraphTableModel() : AbstractTableModel(3, 5, false, false) {
		public override HashSet<string>[] ConsonantsLineSetLookupSet() {
			return [
				[ "\u304E\u3083", "\u304E\u3085", "\u304E\u3087", ],
				[ "\u3058\u3083", "\u3058\u3085", "\u3058\u3087", ],
				[ "\u3062\u3083", "\u3062\u3085", "\u3062\u3087", ],
				[ "\u3073\u3083", "\u3073\u3085", "\u3073\u3087", ],
				[ "\u3074\u3083", "\u3074\u3085", "\u3074\u3087", ],
			];
		}

		public override HashSet<string> ConsonantsSetSet() {
			return [
				"\u304E\u3083", "\u304E\u3085", "\u304E\u3087",
				"\u3058\u3083", "\u3058\u3085", "\u3058\u3087",
				"\u3062\u3083", "\u3062\u3085", "\u3062\u3087",
				"\u3073\u3083", "\u3073\u3085", "\u3073\u3087",
				"\u3074\u3083", "\u3074\u3085", "\u3074\u3087",
			];
		}

		public override HashSet<string>[] VowelsLineSetLookupSet() {
			return [
				[ "\u304E\u3083", "\u3058\u3083", "\u3062\u3083", "\u3073\u3083", "\u3074\u3083", ],
				[ "\u304E\u3085", "\u3058\u3085", "\u3062\u3085", "\u3073\u3085", "\u3074\u3085", ],
				[ "\u304E\u3087", "\u3058\u3087", "\u3062\u3087", "\u3073\u3087", "\u3074\u3087", ],
			];
		}

		public override HashSet<string> VowelsSetSet() {
			return [];
		}
	}
}
