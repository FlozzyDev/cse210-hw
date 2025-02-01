public class Prompt
{
    private List<string> _promptList = new List<string>
    {
        "What was the best part of your day?",
        "What are you grateful for today?",
        "What's something that challenged you today?",
        "What's something you learned today?",
        "What's something you want to remember about today?",
        "How are you feeling right now?",
        "What are your goals for tomorrow?",
        "What made you smile today?",
        "If you could relive any moment from today, what would it be and why?",
        "What made you feel the most alive today?",
        "If today were a chapter in your life story, what would its title be?",
        "What is something you wish you had done differently today?",
        "Who inspired you the most today, and how?",
        "If you had to describe today in three words, what would they be?",
        "What is one thing you noticed today that you often overlook?",
        "How did you show kindness to someone today?",
        "What is a lesson you can take from today?",
        "What was the most unexpected part of your day?",
        "What is one thing you want to carry forward from today into tomorrow?",
        "What small victory did you achieve today?",
        "What surprised you about yourself today?",
        "What did you do today to move closer to your goals?",
        "How did you step out of your comfort zone today?",
        "What is something you discovered about someone else today?",
        "What was your biggest distraction today, and how did you handle it?",
        "If today was a gift, what was the most valuable part of it?",
        "What is one thing you can celebrate about today?",
        "What is a question you wish someone had asked you today?",
        "How did you practice self-care today?",
        "What is something you would like to thank yourself for today?",
        "What is something you would like to thank someone else for today?",
        "What was the most memorable moment of today?", 
    };

    public string GeneratePrompt() /* I realized this is pretty weak and should probably be put in a temp set or something to avoid repeats */
    {
        Random random = new Random(); 

        int choice = random.Next(_promptList.Count);
        return _promptList[choice];
    }
}