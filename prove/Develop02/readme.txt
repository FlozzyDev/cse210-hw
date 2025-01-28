Going to use this form to track the extra features I want to add. I may not have the time to add them all, but I will list my thoughts.

----------------Extra features------------------------
Add a mood rating to each entry (1-10) - Complete!
Add a mood average whenever displaying a journal - Complete!
Add a password - Zion - Complete!
Add multiple (3) password entry attempts. If attempts == 2, console.WriteLine{hint} - Not Complete =(
Add the number of entries in memory next to  "Save" and "Display" - Complete!
Add the number of entries in the file prior to loading - Not Complete 
Add a unique number (RID) per record (created at save) that iterates 1++ (need to first read the file and find the MAX int) - Not Complete 
Check the RID prior to save (to make sure no overwrites/dupes) - Not Complete 
Check the RID when loading to only add missing records to memory (I save 1 entry, then I load. I don't want 2 of them) - Not Complete

---------------Notes----------------

I really don't like the save/load method, I think auto save upon an entry being complete would make more sense. I don't think I can change it, so instead
I'm thinking of adding a primary key type unique ID for each entry created, and then use that key to verify saves/loads. 

I'm going to try and use LINQ as well - trying to get used to using it so I can hopefully transition to JET in GO easier 

