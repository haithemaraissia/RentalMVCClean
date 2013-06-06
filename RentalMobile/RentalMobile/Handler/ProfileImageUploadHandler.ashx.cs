﻿using System;
using System.Drawing;
using System.IO;
using System.Web;
using Westwind.plUpload;

namespace RentalMobile.Handler
{

    /// <summary>
    /// This class is an application level implementation of an uploader
    /// 
    /// This uploader subclasses plUploadFileHandler which downloads files
    /// into a temporary folder (~/tempuploads) and then resizes the image,
    /// renames it and copies it a final destination (~/UploadedImages)
    /// 
    /// This handler also deletes old files in both of those folders
    /// just to keep the size of this demo reasonable.
    /// </summary>s
    public class ProfileImageUploadHandler : plUploadFileHandler
    {
        public string ImageStoragePath = "~/UploadedImages";
        public static int ImageHeight = 480;

        public ProfileImageUploadHandler()
        {
            // Normally you'd set these values from config values
            FileUploadPhysicalPath = "~/tempuploads";
            MaxUploadSize = 2000000;
            AllowedExtensions = ".jpg,.jpeg,.png,.gif,.bmp";
        }

        protected override void OnUploadCompleted(string fileName, string directory)
        {
            var Server = Context.Server;

            // Physical Path is auto-transformed
            var path = FileUploadPhysicalPath;

            var fullUploadedFileName = Path.Combine(path, fileName);

            // Typically you'd want to ensure that the filename is unique
            // Some ID from the database to correlate - here I use a static img_ prefix
            string generatedFilename = "img_" + fileName;

            string imagePath = Server.MapPath(ImageStoragePath) + directory;

            //ImagePathDirectory
            //Create Directory if this is the first file
            CreateDirectoryIfNotExist(imagePath);

            try
            {
                // resize the image and write out in final image folder
                ResizeImage(fullUploadedFileName, Path.Combine(imagePath, generatedFilename), ImageHeight);

                // delete the temp file
                File.Delete(fullUploadedFileName);
            }
            catch (Exception ex)
            {
                WriteErrorResponse("Unable to write out uploaded file: " + ex.Message);
                return;
            }
            ImageStoragePath = ImageStoragePath + directory;
            string relativePath = VirtualPathUtility.ToAbsolute(ImageStoragePath);
            string finalImageUrl = relativePath + "/" + generatedFilename;

            // return just a string that contains the url path to the file
            WriteUploadCompletedMessage(finalImageUrl);
        }

        protected override bool OnUploadStarted(int chunk, int chunks, string name)
        {
            // time out files after 15 minutes - temporary upload files
            DeleteTimedoutFiles(Path.Combine(FileUploadPhysicalPath, "*.*"), 900);

            // clean out final image folder too
            DeleteTimedoutFiles(Path.Combine(Context.Server.MapPath(ImageStoragePath), "*.*"), 900);

            return base.OnUploadStarted(chunk, chunks, name);
        }

        // these aren't needed in this example and with files in general
        // use these to stream data into some alternate data source
        // when directly inheriting from the base handler

        //protected override bool  OnUploadChunk(Stream chunkStream, int chunk, int chunks, string fileName)
        //{
        //     return base.OnUploadChunk(chunkStream, chunk, chunks, fileName);
        //}

        //protected override bool OnUploadChunkStarted(int chunk, int chunks, string fileName)
        //{
        //    return true;
        //}




        /// <summary>
        /// Addition of Helper function to create and/or delete directory
        /// </summary>
        /// <param name="newDirectory"></param>
        private void CreateDirectoryIfNotExist(string newDirectory)
        {
            try
            {
                // Checking the existence of directory
                if (!Directory.Exists(newDirectory))
                {

                    //If No any such directory then creates the new one
                    Directory.CreateDirectory(newDirectory);
                }
                else
                {
                    //Directory already exist
                }
            }
            catch (IOException _err)
            {
                Response.Write(_err.Message);
            }
        }
        private void DeleteDirectoryIfExist(string newDirectory)
        {
            try
            {
                // Checking the existence of directory
                if (Directory.Exists(newDirectory))
                {
                    //If No any such directory then creates the new one
                    Directory.Delete(newDirectory);
                }
                else
                {
                    //Directory doesn't exist
                }
            }
            catch (IOException _err)
            {
                Response.Write(_err.Message);
            }
        }



        #region Sample Helpers
        /// <summary>
        /// Deletes files based on a file spec and a given timeout.
        /// This routine is useful for cleaning up temp files in 
        /// Web applications.
        /// </summary>
        /// <param name="filespec">A filespec that includes path and/or wildcards to select files</param>
        /// <param name="seconds">The timeout - if files are older than this timeout they are deleted</param>
        public static void DeleteTimedoutFiles(string filespec, int seconds)
        {
            string path = Path.GetDirectoryName(filespec);
            string spec = Path.GetFileName(filespec);
            string[] files = Directory.GetFiles(path, spec);

            foreach (string file in files)
            {
                try
                {
                    if (File.GetLastWriteTimeUtc(file) < DateTime.UtcNow.AddSeconds(seconds * -1))
                        File.Delete(file);
                }
                catch { }  // ignore locked files
            }
        }

        /// <summary>
        /// Creates a resized bitmap from an existing image on disk. Resizes the image by 
        /// creating an aspect ratio safe image. Image is sized to the larger size of width
        /// height and then smaller size is adjusted by aspect ratio.
        /// 
        /// Image is returned as Bitmap - call Dispose() on the returned Bitmap object
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns>Bitmap or null</returns>
        public static bool ResizeImage(string filename, string outputFilename,
                                       int height)
        {
            Bitmap bmpOut = null;

            try
            {
                Bitmap bmp = new Bitmap(filename);
                System.Drawing.Imaging.ImageFormat format = bmp.RawFormat;

                decimal ratio;
                int newWidth = 0;
                int newHeight = 0;

                //*** If the image is smaller than a thumbnail just return it
                if (bmp.Height < height)
                {
                    if (outputFilename != filename)
                        bmp.Save(outputFilename);
                    bmp.Dispose();
                    return true;
                }

                ratio = (decimal)height / bmp.Height;
                newHeight = height;
                newWidth = Convert.ToInt32(bmp.Width * ratio);


                bmpOut = new Bitmap(newWidth, newHeight);
                Graphics g = Graphics.FromImage(bmpOut);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.FillRectangle(Brushes.White, 0, 0, newWidth, newHeight);
                g.DrawImage(bmp, 0, 0, newWidth, newHeight);

                bmp.Dispose();

                bmpOut.Save(outputFilename, format);
                bmpOut.Dispose();
            }
            catch (Exception ex)
            {
                var msg = ex.GetBaseException();
                return false;
            }

            return true;
        }

        #endregion

    }
}