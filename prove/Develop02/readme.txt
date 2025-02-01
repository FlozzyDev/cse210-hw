Going to use this form to track the extra features I want to add / thoughts as I work through. 

----------------Extra features------------------------
Add a mood rating to each entry (1-10) - Complete!
Add a mood average whenever displaying a journal - Complete!
Add a password - Zion - Complete!
Add multiple (3) password entry attempts. If attempts == 2, console.WriteLine{hint} - half-complete - need to add hint at 2.
Add the number of entries in local next to  "Save" and "Display" in menu- Complete!
Add the number of entries in the file next to "Load" in menu - Not Complete 
Add a unique number (RID) per record (created at save) that iterates 1++ (need to first read the file and find the MAX int) - Not Complete 
Check the RID prior to save (to make sure no overwrites/dupes) - Not Complete 
Check the RID when loading to only add missing records to memory (I save 1 entry, then I load. I don't want 2 of them) - Not Complete
Improvement - Make sure prompts are not repeated. Thinking of creating a separate file(usedPrompts.txt) to hold used ones. Once all have been used it can be cleared and reset - Not Complete

---------------Notes----------------

I really don't like the save/load method, I think auto save upon an entry being complete would make more sense. Also we need to auto-load when we first call DisplayMainMenu().
I don't think I can change it, so instead I'm thinking of adding a 'primary key' type unique ID for each entry created, and then use that key to verify saves/load states of each entry. 

I'm going to try and use LINQ as well - trying to get used to using it so I can hopefully transition to JET in GO easier

For the unique ID, I think I'm going to add another varible to a entry when it's created, and increment it by 1 as each entry is added. I want to
make sure that the existing numbers inside of the journal.txt are considered, since we want to increment ++i from max.

Refresh function after most actions? 

I sadly did not have time to finish the things I wanted. I think the thing that bothers me the most is it's very easy to over write the journal.txt. 
