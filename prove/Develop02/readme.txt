Outline Journal Activity 

Class - Start Menu 
{ Write / Display / Load / Save / Quit}

WriteOption - Display prompt + gives user ability to enter text. Once user enters data, save to variable list.

All entries need date / prompt / text 

Display - Iterate through variable list and display date / prompt / text for each 

Save - Save the list to file specified 

Load - Load list into the program and set it's value to variable list

quit - end program

-------------

Variables

_prompt
-responseText - The text of a user response
_date - Need to get from computer -DateTime theCurrentTime = DateTime.Now; / string _date = theCurrentTime.ToShortDateString();

data Class - Entry - a _date, _prompt, and _responseText 

_entryList - public List<Entry> _entrysList = new List<Entry>();
_promptList - public List<Prompt> _promptList = new List<Prompt>();

Main Classes
Program / Setup - first initilize the 2 lists (entry/prompt)
Main - Display the menu (while var = true console.Write XXX and then var = false when user picks quit)

Sub-classes or 1 class for tools? May keep them all within entry since tthey are related.
WriteEntry - _date = now, prompt = random | display text prompt | ReadLine = _responseText | Call Entry class and save (Entry latestEntry = new Entry(date, prompt, responseText + add it))
DisplayEntry - If entry 0, tell them. Else, write out entry in format. 
SaveEntry - if 0 entries, tell them. Else, ask for a file name to write to. Need to look at what the syntax for writing is 
LoadEntry - If file exists, clear the current EntryList and then set a new entry for each line. 






