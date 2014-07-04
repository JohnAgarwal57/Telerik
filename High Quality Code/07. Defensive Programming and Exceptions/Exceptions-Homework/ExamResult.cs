using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("Maximal grade must be bigger then minimal!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade 
    { 
        get
        {
            return this.grade;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Grade can't be negative");
            }

            this.grade = value;
        }
    }

    public int MinGrade 
    {
        get
        {
            return this.minGrade;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("The minimal grade can't be negative");
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade 
    {
        get
        {
            return this.maxGrade;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("The maximal grade can't be negative");
            }

            this.maxGrade = value;
        }
    }

    public string Comments 
    {
        get
        {
            return this.comments;
        }

        private set
        {
            if (value == null)
            {
                throw new ArgumentNullException("The comments can't be null");
            }

            if (value == string.Empty)
            {
                throw new ArgumentException("The comments can't be empty");
            }

            this.comments = value;
        } 
    }
}
