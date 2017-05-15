**DataContext**

**DataContext** is one of the most fundamental concepts in Data Binding.
The Binding object needs to get its data from somewhere, and there are a few ways to specify the source of the data like 
using Source property directly in the Binding, inheriting a DataContext from the nearest element when traversing up in the tree, 
setting the ElementName and RelativeSource properties in the Binding object.

User interface elements in WPF have a DataContext dependency property. That property has the aforementioned "value inheritance"
feature enabled, so if you set the DataContext on an element to a Student object, the DataContext property on all of its logical 
descendant elements will reference that Student object too. This means that all data bindings contained within that root element’s
element tree will automatically bind against the Student object, unless explicitly told to bind against something else. This feature
is extremely useful while designing WPF applications. In the following example, we are setting the DataContext in the code and all
the elements in the window get to access the Student object.
