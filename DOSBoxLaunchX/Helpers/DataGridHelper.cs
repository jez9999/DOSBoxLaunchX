using DOSBoxLaunchX.Logic.DosboxParsing;
using DOSBoxLaunchX.Logic.Models;
using DOSBoxLaunchX.Models;

namespace DOSBoxLaunchX.Helpers;

internal static class DataGridHelper {
	#region Private methods

	private static DataGridViewTextBoxColumn makeTextCol(string name, string headerText, bool readOnly, string dataPropertyName, int width = 100, DataGridViewColumnSortMode sortMode = DataGridViewColumnSortMode.NotSortable, DataGridViewAutoSizeColumnMode autoSizeMode = DataGridViewAutoSizeColumnMode.NotSet)
		=> new() {
			Name = name,
			HeaderText = headerText,
			Width = width,
			ReadOnly = readOnly,
			DataPropertyName = dataPropertyName,
			SortMode = sortMode,
			AutoSizeMode = autoSizeMode,
		};

	#endregion

	internal static void InitMappingsDataGrid(DataGridView grid, Func<string, ControlInfo, bool> validateTextCtrlContent, Action controlValueChanged) {
		grid.Columns.Clear();

		grid.Columns.Add(makeTextCol("Section", "Section", true, "Section", 150));
		grid.Columns.Add(makeTextCol("Key", "Key", true, "Key", 250));
		grid.Columns.Add(makeTextCol("ExistingMapping", "Existing Mapping", true, "ExistingMapping", 350));
		grid.Columns.Add(makeTextCol("NewMapping", "New Mapping", false, "NewMapping", autoSizeMode: DataGridViewAutoSizeColumnMode.Fill));

		var colIsSet = new DataGridViewCheckBoxColumn {
			Name = "IsSet",
			HeaderText = "Set",
			Width = 40,
			DataPropertyName = "IsSet",
			SortMode = DataGridViewColumnSortMode.NotSortable,
		};
		colIsSet.HeaderCell.Style.Font = new Font(grid.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
		colIsSet.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
		grid.Columns.Add(colIsSet);

		grid.EnableHeadersVisualStyles = false;
		grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
		grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

		// General DataGridView settings
		grid.ScrollBars = ScrollBars.Vertical;
		grid.RowHeadersVisible = false;
		grid.AllowUserToAddRows = false;
		grid.AllowUserToDeleteRows = false;
		grid.AllowUserToOrderColumns = false;
		grid.AllowUserToResizeColumns = false;
		grid.AllowUserToResizeRows = false;
		grid.AutoGenerateColumns = false;

		// Handle enabling/disabling NewMapping based on IsSet
		grid.CellValueChanged += (sender, ea) => {
			if (ea.RowIndex < 0) { return; }

			var isSetCol = grid.Columns["IsSet"];
			var newMappingCol = grid.Columns["NewMapping"];
			var colName = grid.Columns[ea.ColumnIndex].Name;
			if (
				isSetCol == null ||
				newMappingCol == null ||
				ea.RowIndex < 0
			) {
				return;
			}

			if (colName == "IsSet" || colName == "NewMapping") {
				controlValueChanged();
			}
			if (colName == "IsSet") {
				// Enable/disable NewMapping cell
				var isSetCell = (DataGridViewCheckBoxCell)grid.Rows[ea.RowIndex].Cells[isSetCol.Index];
				var newMappingCell = grid.Rows[ea.RowIndex].Cells[newMappingCol.Index];
				newMappingCell.ReadOnly = !(bool)(isSetCell.Value ?? false);
				grid.InvalidateRow(ea.RowIndex);
			}
		};

		grid.CellValidating += (sender, ea) => {
			if (ea.RowIndex < 0) { return; }
			var colName = grid.Columns[ea.ColumnIndex].Name;
			if (colName != "NewMapping") { return; }

			var text = ea.FormattedValue?.ToString() ?? "";
			if (!validateTextCtrlContent(text, new())) { ea.Cancel = true; }
		};

		// Ensure the CellValueChanged fires when user clicks checkbox
		grid.CurrentCellDirtyStateChanged += (sender, ea) => {
			if (grid.IsCurrentCellDirty) {
				grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		};

		// Format NewMapping based on whether it's disabled or not
		grid.CellFormatting += (sender, ea) => {
			if (ea.RowIndex >= 0) {
				var colName = grid.Columns[ea.ColumnIndex].Name;
				if (colName is "NewMapping") {
					var row = grid.Rows[ea.RowIndex];
					var isSet = row.Cells["IsSet"].Value as bool? ?? false;

					if (!isSet) {
						ea.CellStyle.BackColor = Color.LightGray;
						ea.CellStyle.ForeColor = Color.DarkGray;
					}
					else {
						ea.CellStyle.BackColor = grid.DefaultCellStyle.BackColor;
						ea.CellStyle.ForeColor = grid.DefaultCellStyle.ForeColor;
					}
				}
				else if (colName is "Section" or "Key" or "ExistingMapping") {
					ea.CellStyle.BackColor = Color.WhiteSmoke;
					ea.CellStyle.ForeColor = Color.Black;
				}
			}
		};

		// Enforce readonly cells on data binding complete
		grid.DataBindingComplete += (_, _) => {
			foreach (DataGridViewRow row in grid.Rows) {
				bool isSet = row.Cells["IsSet"].Value as bool? ?? false;
				row.Cells["NewMapping"].ReadOnly = !isSet;
			}
		};
	}

	internal static void LoadKeyboardMappingsToGrid(IEnumerable<MapperMappingLine>? baseMappings, List<KeyboardMapping> overrides, DataGridView grid) {
		var gridData = new List<KeyboardMappingGridRow>();

		if (baseMappings != null) {
			// Show base mappings with overrides merged in
			foreach (var line in baseMappings) {
				var section = (line.Section ?? "").ToLowerInvariant();
				var key = line.Key.ToLowerInvariant();
				var existing = line.Value;

				// Look for an override, if present
				var overrideMapping = overrides.FirstOrDefault(entry =>
					entry.Section.ToLowerInvariant() == section &&
					entry.Key.ToLowerInvariant() == key
				);

				gridData.Add(new KeyboardMappingGridRow {
					Section = section,
					Key = key,
					ExistingMapping = existing,
					NewMapping = overrideMapping?.Mapping ?? "",
					IsSet = overrideMapping != null
				});
			}
		}
		else {
			// Base missing: just show overrides
			foreach (var entry in overrides) {
				gridData.Add(new KeyboardMappingGridRow {
					Section = entry.Section,
					Key = entry.Key,
					ExistingMapping = "",
					NewMapping = entry.Mapping,
					IsSet = true
				});
			}
		}

		grid.DataSource = gridData;
	}
}

internal sealed class KeyboardMappingGridRow {
	public string Section { get; set; } = "";
	public string Key { get; set; } = "";
	public string ExistingMapping { get; set; } = "";
	public string NewMapping { get; set; } = "";
	public bool IsSet { get; set; }
}
