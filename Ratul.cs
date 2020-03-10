using System.Collections.Generic;

namespace DesignPatterns.MidSemester
{
    public class Ratul
    {
        Action action;
        public Ratul(Action action)
        {
            this.action = action;
        }
        public string ExecuteCloseAction()
        {
            List<string> ls = (List<string>)action.ExecuteAction();
            return ls[0];
        }

        public IEnumerable<string> ExecuteDistantAction()
        {
            // you can return a array or list of string. Both array and list are subtypes of IEnumerable
            // However, there is a thing called `yield return` in C#.
            // Using it would be "cool"
            // Make sure you understand it if you choose to use it.
            return action.ExecuteAction();
        }
    }
    public interface Action
    {
        public IEnumerable<string> ExecuteAction();
    }
    public abstract class CloseAction:Action
    {
        public abstract IEnumerable<string> ExecuteAction();
    }
    public abstract class DistantAction : Action
    {
        public abstract IEnumerable<string> ExecuteAction();
        public IEnumerable<string> SequenceOfActions()
        {
            return new List<string>() { Move(),Grab(),Hit() };
        }
        public string Move()
        {
            return "move";
        }
        public abstract string Grab();
        public abstract string Hit();
    }
    public class Punch : CloseAction
    {

        public override IEnumerable<string> ExecuteAction()
        {
            return new List<string>() { "punch" };
        }
    }
    public class Kick : CloseAction
    {

        public override IEnumerable<string> ExecuteAction()
        {
            return new List<string>() { "kick" };
        }
    }
    public class Head : CloseAction
    {

        public override IEnumerable<string> ExecuteAction()
        {
            return new List<string>() { "head head" };
        }
    }
    public class Power:DistantAction
    {
        public override IEnumerable<string> ExecuteAction()
        {
            return SequenceOfActions();
        }
        public override string Grab()
        {
            return "pick up";
        }
        public override string Hit()
        {
            return "slam!";
        }
    }
    public class Skill : DistantAction
    {
        public override IEnumerable<string> ExecuteAction()
        {
            return SequenceOfActions();
        }
        public override string Grab()
        {
            return "hold collar";
        }
        public override string Hit()
        {
            return "knee! knee!! knee!!!";
        }
    }
}
