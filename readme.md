As others have mentioned, there is no bug here as shown in this sequence of selecting Item 1, then Selecting Item2 (which first changes the selection by deselecting Item 1.

![screenshot1](https://github.com/IVSoftware/list_view_freeze/blob/master/list_view_freeze/Screenshots/ss1.png)

If you don't want the User to be selecting things during some arbitrary task, why not just set `ListView.Enabled` to `false`  while you perform the work? In the testcode referenced below, I made an all-in-one for when the checkbox changes that sets the `SelectionIndices` collection to '2' as in your post;

![screenshot1](https://github.com/IVSoftware/list_view_freeze/blob/master/list_view_freeze/Screenshots/ss2.png)

There are now no issues going back to a state where `freeze selection` is unchecked and selecting some new item.

![screenshot1](https://github.com/IVSoftware/list_view_freeze/blob/master/list_view_freeze/Screenshots/ss3.png)
```
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
```