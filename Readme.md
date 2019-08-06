# Brigandine GE Data Editor GUI
This project was built using WPF and the .Net Framework 4.6.1, and is a
GUI for the
[Brigandine GE Data Editor Library](https://gitlab.com/dstilwagen/brigandine-ge-ps1-data-viewer).

The GUI is very simple, with a list of the different data types at the
top. Selecting any of the DataTypes will display a DataGrid with columns
for displaying the fields in each DataType.

The DataGrid does allow for editing the values for each DataType but
currently writing back to the SLPS file is not supported but I plan to
have it working soon.

Exert from the
[Brigandine GE Data Editor Library's](https://gitlab.com/dstilwagen/brigandine-ge-ps1-data-viewer)
Readme.md.
># Brigandine GE Data Editor
>#### About Brigandine
>Brigandine Grand Edition or BGE for short is a tactical turn based rpg.
>The game was originally released in Japan and North America in 1998 as
>Brigandine: The Legend of Forsena. In 2000 a new version called
>Brigandine Grand Edition was released but only in Japan and was never
>officially translated. After more than a decade **HwitVlf** at the
>[Sword of Moonlight forums](https://www.swordofmoonlight.com) released
>his own english translation that can be found
>[Here](https://www.swordofmoonlight.com/bbs/index.php?topic=869.0). I
>did change the translation patch slightly by making some names and
>elements closer to their original values. There are plans to include
>this slightly modified version of the translation patch by default. This
>way there is default data and it can be used to patch any SLPS_026
>files.
>#### About This Library
>The only dependency this library has is .Net Standard 2.0, this was done
>so anyone can use this library to build GUI tools for editing the SLPS
>files. A dependency on System.Memory may be added in the future so
>Memory<T> and Span<T> can be used. The purpose of this library is to
>make modding BGE easier including editing names and descriptions. The
>library was created using the information found on the Sword of
>Moonlight forums. The
>[Internet Wayback Machine](https://web.archive.org/) was also used to
>get
>[forsena.org from May 2014](https://web.archive.org/web/20140517111817/http://forsena.org/).
