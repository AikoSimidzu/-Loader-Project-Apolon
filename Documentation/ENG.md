# Documentation
Welcome to this guide, I'm glad you decided to take a look here.

This project was made just for fun;)
# Start
So, let's begin!

To create a build, we need:
1. Environment for working with sources. Personally, I am using VS 2019/2022
Links:

https://visualstudio.microsoft.com/ru/vs/preview/vs2022/

https://visualstudio.microsoft.com/ru/downloads/ (community)

2. Hosting with a panel installed. Installation instructions, etc. https://youtu.be/K-tMGSVgk4A
3. The sources themselves. To do this, go to the main section, click `"Code" -> "Download ZIP"`.
After which we will unzip them to another folder.

And so, in the archive we see the "Sources" folder, compile the `"EncDecr"` project from there, and then run the link to the panel in the application.
# Working with the main build
Open the ApolonSpaceXLoader project, insert there (Class `"Program.cs", string dom`) our link from `"EncrDecr"` and compile it again.

Hooray! This concludes the work! (Well, or almost.)
# Using the console (CMD)
I don’t know why, but I added this feature.

Why not?

To use it, we need to find the `"CMD Control"` tab in the panel, and enter the command we need in the corresponding `textBox`.

A respected user may ask, "what if we need to specify a path, but the machine does not have a" C "drive?".

No problem! For this case, I added getting the path by converting a string.

Example of use in the console:

`cd %AppData%\Apolon`

`cd %UserProfile%\Apolon`

`cd %Documents%\Apolon`

`cd %ProgramFiles%\Apolon`

`cd %Startup%\Apolon`

Example of use in the panel:

`cd {AppData}\Apolon`

`cd {UserProfile}\Apolon`

`cd {Documents}\Apolon`

`cd {ProgramFiles}\Apolon`

`cd {Startup}\Apolon`


It's much easier than it sounds!
# Creating modules and using them
In the project, you can find a class such as `"MyModules.cs"`, which allows us to use our modules.

Important note!
1. Only modules written in C# are supported
2. The class name must be `"Class1"`
3. The name of the main called method `"Start"`, no arguments.
4. Other methods are called through the main `"Start"` method.
5. If you have a loop set up, it should run on a separate thread.
6. When adding a module in the panel, the "Name" parameter must match the name of the project (module). The `"link"` parameter should be direct, for example: `http://malwaregate.site/mymodule.dll`

Thank you for your attention, I hope for your feedback!
