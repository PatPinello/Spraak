**About The Project**

This project is a game developed in Unity about language acquisition. The player gains more and more knowledge about a language by speaking with 
and performing cultural tasks for NPCs. 

**Why:**

Language learning can be extremely fun and rewarding while allowing for the further development of knowledge surrounding other cultures. Additionally,
Natural Language Processing and the princples surrounding it are very interesting. This project allows for the experimentation and design of such tools.

**Built With:**

C#
SQLite

The bulk of the content can be found in both Spraak/Assests/Scripts and Spraak/Assests/ScriptableObjects.

**DatabaseControl** 
    
    This is a script which takes the input of a game object, queries a SQLite database and stores all of its parameters.
    It's written in a way which allows for the stacking of items, but if one parameter is different, a new item will be created
    this is ideal for inventories. I have not finished writing the code to display this information, 
    but it is essentially the same process in reverse.
    
    Additionally, it has the capability of storing how much and the specifics of the language the player has learned.
    
**Acquistion**

    This is a script, still early in development, which compares the language knowledge of the player, to that of the NPC. This is done by
    obtaining the NPCs text, cleaning it up, and building a dictionary from it. The dictionary contains integer keys and 
    the foreign language words as values. This is then compared to the players dictionary. The goal is for the player to learn specfic
    words over time, so nested foreach loops will replace the visible text with which ever words are known by the player. 
    These function are used throughout other scipts aswell.

**Whats Next?**

   The next steps are to:
   
   Create a more sophisticated system of comparing and displaying player and NPC language knowledge.
   
   Implimenting the display of items from a database into a UI.

Contact
Pat Pinello - patpinello114@gmail.com

Project Link: https://github.com/MrSpankledorf/Spraak/tree/master/Assets
