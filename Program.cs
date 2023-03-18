namespace DesignBrowserHistory
{
    internal class Program
    {
        public class BrowserHistory
        {

            private class DoubleLinkedListNode
            {
                public string value;
                public DoubleLinkedListNode next;
                public DoubleLinkedListNode prev;

                public DoubleLinkedListNode(string value, DoubleLinkedListNode next = null, DoubleLinkedListNode prev = null)
                {
                    this.value = value;
                    this.next = next;
                    this.prev = prev;
                }
            }

            private DoubleLinkedListNode linkedListHead;
            private DoubleLinkedListNode currentNode;

            public BrowserHistory(string homepage)
            {
                linkedListHead = new DoubleLinkedListNode(homepage);
                currentNode = linkedListHead;
            }

            public void Visit(string url)
            {
                DoubleLinkedListNode newNode = new(url);
                currentNode.next = newNode;
                newNode.prev = currentNode;
                currentNode = newNode;
            }

            public string Back(int steps)
            {
                while (steps > 0 && currentNode.prev != null)
                {
                    currentNode = currentNode.prev;
                    --steps;
                }
                return currentNode.value;
            }

            public string Forward(int steps)
            {
                while (steps > 0 && currentNode.next != null)
                {
                    currentNode = currentNode.next;
                    --steps;
                }
                return currentNode.value;
            }
        }
        static void Main(string[] args)
        {
            BrowserHistory browserHistory = new BrowserHistory("leetcode.com");
            browserHistory.Visit("google.com");       // You are in "leetcode.com". Visit "google.com"
            browserHistory.Visit("facebook.com");     // You are in "google.com". Visit "facebook.com"
            browserHistory.Visit("youtube.com");      // You are in "facebook.com". Visit "youtube.com"
            Console.WriteLine(browserHistory.Back(1));                   // You are in "youtube.com", move back to "facebook.com" return "facebook.com"
            Console.WriteLine(browserHistory.Back(1));                   // You are in "facebook.com", move back to "google.com" return "google.com"
            Console.WriteLine(browserHistory.Forward(1));                // You are in "google.com", move forward to "facebook.com" return "facebook.com"
            browserHistory.Visit("linkedin.com");     // You are in "facebook.com". Visit "linkedin.com"
            Console.WriteLine(browserHistory.Forward(2));                // You are in "linkedin.com", you cannot move forward any steps.
            Console.WriteLine(browserHistory.Back(2));                   // You are in "linkedin.com", move back two steps to "facebook.com" then to "google.com". return "google.com"
            Console.WriteLine(browserHistory.Back(7));                   // You are in "google.com", you can move back only one step to "leetcode.com". return "leetcode.com"
        }
    }
}