using System.Diagnostics;
using System.Linq;

namespace list_view_freeze
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            listView.View = View.Details;
            listView.FullRowSelect = true;
            listView.MultiSelect = false;
            listView.Columns.Add("col 1");
            for (int i = 1; i <= 4; i++) listView.Items.Add($"Item {i}");

            listView.SelectedIndexChanged += (sender, e) =>
            {
                richTextBox.AppendLine(DateTime.Now);
                var sel =
                    listView
                    .SelectedItems
                    .Cast<ListViewItem>();
                if (sel.Any())
                {
                    foreach (var item in sel)
                    {
                        richTextBox.AppendLine(item);
                        richTextBox.AppendLine();
                    }
                }
                else
                {
                    richTextBox.AppendLine("No selections", Color.Salmon);
                }
            };

            checkBox.CheckedChanged += (sender, e) =>
            {
                listView.Enabled = !checkBox.Checked;
                if (checkBox.Checked)
                {
                    doWork();
                }
            };

            void doWork()
            {
                listView.SelectedIndices.Clear();
                listView.SelectedIndices.Add(2);
            }
        }
    }

    internal class CListView : ListView
    {
        const int WM_KILLFOCUS = 0x0008;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_KILLFOCUS:
                    return;
            }
            base.WndProc(ref m);
        }
    }
    static class Extensions
    {
        public static void AppendLine(this RichTextBox richTextBox) =>
            richTextBox.AppendText($"{Environment.NewLine}");
        public static void AppendLine(this RichTextBox richTextBox, object text) =>
            richTextBox.AppendText($"{text}{Environment.NewLine}");

        public static void AppendLine(this RichTextBox richTextBox, object text, Color color)
        {
            var colorB4 = richTextBox.SelectionColor;
            richTextBox.SelectionColor = color;
            richTextBox.AppendText($"{text}{Environment.NewLine}");
            richTextBox.SelectionColor = colorB4;
        }
    }
}