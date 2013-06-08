ExtendedDotNetContols
=====================

Contains an Extended `ListBox` Control, which has an abstract method `GetChild`. 
Which would be queried when the user scrolls horizontally.
Every scroll will add a set of items to the bottom of the `ListBox` based on the Number of Items that are currently displayed/visible items.

A `Demo application` has been added to showcase this functionality.


Background:
==============

In order to Display a List Box in the UI, and If that list Box has way too much of data. 
User would wait until he retrives all the data and then load it to the UI/ListBox.
Or show a progress bar and load the List in the background.

In both these cases, the End User would have to wait until the List is fully loaded.
The data could be loaded from a Database, Local Disk or Remote Service.
The speed of Loading the List would be directly propotional to both the Size and the read location.

Solution
============

By using `ExtendedListBox` class. 
The user gets a `call back` evey time the user scrolls Horizontally.

The Callback method request for the `index` of the `List` that is about to be displayed in the UI.


