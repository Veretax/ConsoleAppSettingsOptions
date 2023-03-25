# ConsoleAppSettingsOptions
a place to test and dabble learning and practicing the AppSettingsd Options Pattern (not meant for production use)


ConsoleAppSettingsOptions, is actually not an appliciation, but a demonstration.

The goal here was to demonstrate the different ways you might find Json Data in an appsettings file, how you might create a class for each top level json item and then return objects right from the configuration. 

It has examples of the following:


* Empty Json (No json key/value pairs at all)
* Single Key Value Pair
* Two Key Value Pairs (one int32 the other string)
* Examples of Two Values Nested one Level deeper
* Multiple Attributes of different types (int32, int 16, boolean as true, boolean as false, and string)
* Onekey that is a Boolean
* Single Array of String Items
* Examples of a Key-Value Pair, where the value contains an attribute that is its own array
* Examples of a Key that has a complex object which has an array as one of its elements.
* Examples of a Key that has a Key which is an array of complex objects with at least one array in its elements

Some Examples are based on default options you might see in a CMS/Web Project
* Examples of an "Allowed Hosts" option
* Example of Packages as a string Array
* Examples of a Logging Options
* Examples of a LogLevel


This is meant for learning and demonstration purposes only, the Unit tests show how you might build a structure to make it more clear the conventions and patterns you might use.  In the project you find:

* AbstractConfigurationOptions - an Abstract Class which is used to hold the common OpenJson Logic for all configurations (and makes it so you don't have to define this at all.
* IConfigurationOptions - a generic interface that primarily sets up the BindOptions method to have a common way to pass in a default when trying to bind.  (Note I debated making the name of each class be 'Name' instead of being unique in each classes.  One potential change would be to make this name part of the interface, and then change all the string names which represent the key name the option looks for to just Name.  I didn't here to make it clear that it doesn't have to even be included in the pattern. (you could also abstract that away in a settings file also.)
* DefaultAppOptions - It looks like a mother of all default properties (MOAP) but was used to make the defaults easier to see and able to be changed in one place (without having to fix it in all the Unit tests (there may be a few places where the defaults checked against are in the unit tests, but its a testing principle you should consider to make sure your tests fail for reasons in the code, not their current values as defined in the test.

* AppSettingKeys - I originally intended to write tests for these but its not necessary to test a class that is just used to hold data, only the methods.


Feel free to borrow, change, or create your own customizations. Its offered free as is, without warranty or liability covered, for learning.  I hope you find this project helpful in its intent as a demonstration.  
