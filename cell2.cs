public class Row
    {
        private readonly Cell[] cells;

        public Row(Cell[] cells)
        {
            this.cells = cells;

            foreach (Cell cell in this.cells)
            {
                cell.ValueAssigned += OnCellValueAssigned;
            }
        }

        private void OnCellValueAssigned(object sender, CellValueChangedEvent cellValueChangedEvent)
        {
            // Update the other cells
            foreach (Cell cell in cells)
            {
                if (cell.Id != ((Cell)sender).Id)
                {
                    cell.EliminateOption(cellValueChangedEvent.Value);
                }
            }
        }
    }

    public class CellValueChangedEvent
    {
        public int CellId { get; set; }
        public int Value { get; set; }

        public CellValueChangedEvent(int cellId, int value)
        {
            CellId = cellId;
            Value = value;
        }
    }

    public class Cell
    {
        public int Id { get; private set; }
        
        public event EventHandler<CellValueChangedEvent>? ValueAssigned;

        protected virtual void OnValueAssigned(EventArgs e)
        {
            ValueAssigned?.Invoke(this, new CellValueChangedEvent(Id, 5 /* TODO: use actual cell value */ ));
        }

        public void EliminateOption(int value)
        {
            // TODO: remove the value from the options
        }
    }