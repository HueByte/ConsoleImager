# ✨ `ConsoleImager`

<img align="left" width=100 height=100 src="https://i.imgur.com/STghnjI.png"  />

Print your image in console! <br>*Now with all the colors you want*
```
./ConsoleImager {link} {[Optional]height} {[Optional]width}
```

# ⚙️ `Usage`

## 🪟 `Windows`
> Command syntax:
```cs
./ConsoleImager.exe {link} {[Optional]height} {[Optional]width}
```

> Examples: 
```cs
./ConsoleImager.exe "https://upload.wikimedia.org/wikipedia/en/e/ed/Nyan_cat_250px_frame.PNG"
```

```cs
./ConsoleImager.exe "https://upload.wikimedia.org/wikipedia/en/e/ed/Nyan_cat_250px_frame.PNG" 100 
```

```cs
./ConsoleImager.exe "https://upload.wikimedia.org/wikipedia/en/e/ed/Nyan_cat_250px_frame.PNG" 100 50 
```

## 🐧 `Linux`
> Configuration
Allow user to use the program
```cs
chown $USER:$USER ConsoleImager
chmod 755 ./ConsoleImager
```

> Command syntax: 
```cs
./ConsoleImager {link} {[Optional]height} {[Optional]width}
```

## 🏗️ `Build it yourself`
If release doesn't contain your OS system, you can build one by yourself!

Example of publish command in `ConsoleImager/src` folder
```cs
dotnet publish -c release -r linux-x64 -p:PublishSingleFile=true -o ./linux-x64 
```
Publish command docs: https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-publish 

RID publish docs: https://learn.microsoft.com/en-us/dotnet/core/rid-catalog

## Result example
## Draxis
["rendering" video](https://youtu.be/-nEG29wJrjE)
<img src="https://blazebin.net/r/epit9p.png" />
