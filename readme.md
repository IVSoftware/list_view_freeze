As others have mentioned, there is no bug here as shown in this sequence of selecting Item 1, then Selecting Item2 (which first changes the selection by deselecting Item 1.

![screenshot1](https://github.com/IVSoftware/list_view_freeze/blob/master/list_view_freeze/Screenshots/ss1.png)

If you don't want the User to be selecting things during some arbitrary task, why not just set `ListView.Enabled` to `false`  while you perform the work? Here I made an all-in-one when the checkbox changes that sets the SelectionIndices collection to '2';

![screenshot1](https://github.com/IVSoftware/list_view_freeze/blob/master/list_view_freeze/Screenshots/ss2.png)

There are now no issues going back to a state where `freeze selection` is unchecked and selecting some new item..

