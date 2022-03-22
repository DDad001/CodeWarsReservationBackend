using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWarsReservationBackend.Models;
using CodeWarsReservationBackend.Services.Context;
using Microsoft.AspNetCore.Mvc;

namespace CodeWarsReservationBackend.Services
{
    public class CohortService
    {
        private readonly DataContext _context;
        
        public CohortService(DataContext context)
        {
            _context = context;
        }
        
        public bool AddCohort (CohortService newCohort)
        {
            _context.Add(newCohort);
            return _context.SaveChanges() != 0;
        }


        public IEnumerable<ProjectItemModel> GetAllProjectItems()
        {
            return _context.ProjectItemInfo;
        }

        public ProjectItemModel GetProjectItemsById(int id)
        {
            return _context.ProjectItemInfo.SingleOrDefault(item => item.Id == id);
        }

        public IEnumerable<ProjectItemModel> GetProjectItemsByUserId(int userId)
        {
            return _context.ProjectItemInfo.Where(item => item.UserId == userId);
        }


        public IEnumerable<CohortService> GetCohortByCohortName(string cohortName)
        {
            return _context.CohortInfo.Where(item => item.CohortName == cohortName);
        }

        public IEnumerable<ProjectItemModel> GetProjectItemByDescription(string description)
        {
            return _context.ProjectItemInfo.Where(item => item.Description == description);
        }

        public IEnumerable<ProjectItemModel> GetProjectItemByDateCreated(string dateCreated)
        {
            return _context.ProjectItemInfo.Where(item => item.DateCreated == dateCreated);
        }

        public IEnumerable<ProjectItemModel> GetProjectItemByDueDate(string dueDate)
        {
            return _context.ProjectItemInfo.Where(item => item.DueDate == dueDate);
        }

        public IEnumerable<ProjectItemModel> GetProjectItemsByStatus(string status)
        {
            return _context.ProjectItemInfo.Where(item => item.Status == status);
        }

        // Get a ProjectItem by a memberId
        public List<ProjectItemModel> GetProjectItemsByAMemberId(string memberId)
        {
           //"Tag1, Tag2, Tag3,Tag4"
            List<ProjectItemModel> AllProjectsWithMemberId = new List<ProjectItemModel>();//[]
            var allItems = GetAllProjectItems().ToList();//{Tag:"Tag1, Tag2",Tag:"Tag2",Tag:"tag3"}
            for(int i=0; i < allItems.Count; i++)
            {
                ProjectItemModel Item = allItems[i];//{Tag:"Tag1, Tag2"}
                var itemArr = Item.MembersId.Split(",");//["Tag1","Tag2"]
                for(int j = 0; j < itemArr.Length; j++)
                {   //Tag1 j = 0
                    //Tag2 j = 1
                    if(itemArr[j].Contains(memberId))
                    {// Tag1               Tag1
                        AllProjectsWithMemberId.Add(Item);//{Tag:"Tag1, Tag2"}
                    }
                }
            }
            return AllProjectsWithMemberId;
        }

        // Get a ProjectItem by a memberUsername
        public List<ProjectItemModel> GetProjectItemsByAMemberUsername(string memberUsername)
        {
           //"Tag1, Tag2, Tag3,Tag4"
            List<ProjectItemModel> AllProjectsWithMemberUsername = new List<ProjectItemModel>();//[]
            var allItems = GetAllProjectItems().ToList();//{Tag:"Tag1, Tag2",Tag:"Tag2",Tag:"tag3"}
            for(int i=0; i < allItems.Count; i++)
            {
                ProjectItemModel Item = allItems[i];//{Tag:"Tag1, Tag2"}
                var itemArr = Item.MembersUsername.Split(",");//["Tag1","Tag2"]
                for(int j = 0; j < itemArr.Length; j++)
                {   //Tag1 j = 0
                    //Tag2 j = 1
                    if(itemArr[j].Contains(memberUsername))
                    {// Tag1               Tag1
                        AllProjectsWithMemberUsername.Add(Item);//{Tag:"Tag1, Tag2"}
                    }
                }
            }
            return AllProjectsWithMemberUsername;
        }
        
        public IEnumerable<ProjectItemModel> GetDeletedProjectItems()
        {
            return _context.ProjectItemInfo.Where(item => item.IsDeleted);
        }

        public IEnumerable<ProjectItemModel> GetArchivedProjectItems()
        {
            return _context.ProjectItemInfo.Where(item => item.IsArchived);
        }

        public bool UpdateCohort(CohortModel updatedCohort)
        {
            _context.Update<CohortModel>(updatedCohort);
            return _context.SaveChanges() != 0;
        }

         public bool ArchiveCohort (CohortModel CohortArchived)
        {
            CohortArchived.IsArchived = true;
            _context.Update<CohortModel>(CohortArchived);
            return _context.SaveChanges() !=0;
        }
        
    }
}