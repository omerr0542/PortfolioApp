﻿namespace PortfolioApp.Web.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string GitHubUrl { get; set; }
        public Category Category { get; set; }
        //public int CategoryId { get; set; }
    }
}
