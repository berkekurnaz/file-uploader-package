# File Uploader Package
File uploader package for .net core apps. You can do file upload, file update and file delete operations using this package. <br/>
It greatly simplifies jobs and file-related jobs are simplified. 
You can find examples below. Also [click for example](https://github.com/berkekurnaz/file-uploader-package/tree/master/FileUploader.Test) .net core application.

> **Nuget :** https://www.nuget.org/packages/File_Uploader <br/>

> **Tutorial (English) :** Coming Soon...

> **Tutorial (Turkish) :** Coming Soon...



## Installation
- Download this package to your project.
```bash
Install-Package File_Uploader -Version 1.0.0
```

## How to use this package ?
- Upload a new file
```csharp
await FileUploaderOperations.UploadFile(IFormFile, fileName, fileFolder)
```
- Update a file by file name
```csharp
await FileUploaderOperations.UpdateFile(IFormFile, newFileName, fileFolder, updateFileName)
```
- Delete a file by file name
```csharp
await FileUploaderOperations.DeleteFile(fileName, fileFolder)
```


## Contact
> Developer: Berke Kurnaz

> Mail Address: contact@berkekurnaz.com <br/>
> Mail Address: kurnaz.berke1907@gmail.com

> Github: https://github.com/berkekurnaz