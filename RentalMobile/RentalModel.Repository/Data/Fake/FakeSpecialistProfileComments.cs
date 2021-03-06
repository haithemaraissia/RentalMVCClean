using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeSpecialistProfileComments
    { 
       public List<SpecialistProfileComment> MySpecialistProfileComments;

       public FakeSpecialistProfileComments()
        {
            InitializeSpecialistProfileCommentList();
        }

       public void InitializeSpecialistProfileCommentList()
        {
            MySpecialistProfileComments = new List<SpecialistProfileComment> {
                FirstSpecialistProfileComment(), 
                SecondSpecialistProfileComment(),
                ThirdSpecialistProfileComment()
            };
        }

       public SpecialistProfileComment FirstSpecialistProfileComment()
        {

            var firstSpecialistProfileComment = new SpecialistProfileComment {

                 CommentId = 1
,
                 SpecialistId = 2,
                 PosterId = new Int32(),
                 PosterRole = new Int32(),
                 PosterName = null,
                 PosterPhotoPath = null,
                 Comment = null,
                 CommentDate = new DateTime(),
                 PosterProfileLink = null
    
 };

            return firstSpecialistProfileComment;
        }

       public SpecialistProfileComment SecondSpecialistProfileComment()
        {

            var secondSpecialistProfileComment = new SpecialistProfileComment {

                 CommentId = 2
,
                 SpecialistId = 2,
                 PosterId = new Int32(),
                 PosterRole = new Int32(),
                 PosterName = null,
                 PosterPhotoPath = null,
                 Comment = null,
                 CommentDate = new DateTime(),
                 PosterProfileLink = null
        
 };

            return secondSpecialistProfileComment;
        }

       public SpecialistProfileComment ThirdSpecialistProfileComment()
        {

            var thirdSpecialistProfileComment = new SpecialistProfileComment {

                 CommentId = new Int32()
,
                 SpecialistId = new Int32(),
                 PosterId = new Int32(),
                 PosterRole = new Int32(),
                 PosterName = null,
                 PosterPhotoPath = null,
                 Comment = null,
                 CommentDate = new DateTime(),
                 PosterProfileLink = null
 
 };

            return thirdSpecialistProfileComment;
        }

        ~FakeSpecialistProfileComments()
        {
            MySpecialistProfileComments = null;
        }
    }
}


    