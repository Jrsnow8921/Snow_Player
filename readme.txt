C# Movie Player
Based upon the Microsoft.DirectX.AudioVideoPlayback assembly.

In order to use this code (with VISTA) you must first download the latest DirectX SDK there:
http://www.microsoft.com/downloads/details.aspx?familyid=86cf7fa2-e953-475c-abde-f016e4f7b61a&displaylang=en

Once installed, the full documentation is in this folder:
C:\Program Files\Miscrosoft DirectX SDK (April 2007)\Documentation\DirectX9\directx9_m.chm

To get rid of the "loaderlock" exception message while running in the VS environment:
Use "Ctrl + Alt + E" to open the Exceptions dialog box,
select "Managed Debugging Assistants" and uncheck "Loaderlock".

zMoviePlayer is able to play: avi, mpg, mpeg, wmv, DivX, Xvid.
(assuming that you have installed the right CODEC first)

While in "full screen" mode, move the mouse to the bottom to show/hide the "command panel".
To select a movie, use either the Menu to popup the common dialog file selector,
or use Drag & Drop from the Explorer onto the zMoviePlayer form.

Patrice Terrier
www.zapsolution.com

PS: You can download all my C# demo there
http://www.zapsolution.com/winlift/ccorner.htm
(make sure to try the amazing "carousel" demo!)
