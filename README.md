# Listen

This solution was created for demostrating a problem with the CommunityToolkit.Maui speechToText.ListenAsync function not awaiting completion in an iOS application instance. An Android instance functions properly. 

Simply build the application and start debugging on an iPhone. Select the "Click me" button on the main page, then attempt to speak. A breakpoint is set on the code line after the ListenAsync method is called in the GetVocalResponse() method. It should be hit before you have tried to speak, demonstrating the issue.
