using System.IO;

namespace HuceDocs.Services
{
    public interface IFileManagerIO
    {
        char DirectorySeparatorChar { get; }
        bool FileExists(string filePath);
        void FileDelete(string filePath);
        bool DirectoryExists(string dirPath);
        void DirectoryDelete(string dirPath);
        void DirectoryCreate(string dirPath);
        //void FileMove(string source, string destination);
        string GetDirectoryPath(string filePath);
        string PathCombine(string path1, string path2);
        string PathCombine(string path1, string path2, string path3);
        string GetFullFilePath(string relativePath);
        string GetFilePath(int userId, int typeId, int inOutPut, string extension);
        string GetFileServerAnalysisPath(int typeId, int? docTypeId, int inOutPut, string extension);
        void FileMove(string fromFilePath, string toFilePath);
        void FileCopy(string fromFilePath, string toFilePath);
        Stream GetFileData(string filePath);
    }
}
