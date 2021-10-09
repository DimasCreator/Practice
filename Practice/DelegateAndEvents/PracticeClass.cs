using System;

namespace Practice.DelegateAndEvents
{
    
    
    

    
    
    
    // // Пример с msdn
    //
    // // Publisher pub = new Publisher();
    // // Subscriber sub1 = new Subscriber("123", pub);
    // // Subscriber sub2 = new Subscriber("412412", pub);
    // //
    // // pub.DoSomething();
    //
    //
    // // Define a class to hold custom event info
    // public class CustomEventArgs : EventArgs
    // {
    //     public CustomEventArgs(string message)
    //     {
    //         Message = message;
    //     }
    //
    //     public string Message { get; set; }
    // }
    //
    // // Class that publishes an event
    // public class Publisher
    // {
    //     // Declare the event using EventHandler<T>
    //     public event EventHandler<CustomEventArgs> RaiseCustomEvent;
    //
    //     public void DoSomething()
    //     {
    //         // Write some code that does something useful here
    //         // then raise the event. You can also raise an event
    //         // before you execute a block of code.
    //         OnRaiseCustomEvent(new CustomEventArgs("Event triggered"));
    //     }
    //
    //     // Wrap event invocations inside a protected virtual method
    //     // to allow derived classes to override the event invocation behavior
    //     protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
    //     {
    //         // Make a temporary copy of the event to avoid possibility of
    //         // a race condition if the last subscriber unsubscribes
    //         // immediately after the null check and before the event is raised.
    //
    //         e.Message += "  " + DateTime.Now;
    //         RaiseCustomEvent?.Invoke(this, e);
    //     }
    // }
    //
    // //Class that subscribes to an event
    // public class Subscriber
    // {
    //     private readonly string _id;
    //
    //     public Subscriber(string id, Publisher pub)
    //     {
    //         _id = id;
    //
    //         // Subscribe to the event
    //         pub.RaiseCustomEvent += HandleCustomEvent;
    //     }
    //
    //     // Define what actions to take when the event is raised.
    //     void HandleCustomEvent(object sender, CustomEventArgs e)
    //     {
    //         Console.WriteLine($"{_id} received this message: {e.Message}");
    //     }
    // }

}