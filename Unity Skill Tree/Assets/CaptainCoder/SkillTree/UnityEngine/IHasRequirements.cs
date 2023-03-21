using System.Collections.Generic;
namespace CaptainCoder.SkillTree.UnityEngine
{
    public interface IHasRequirements<E, S> where E : ISkilledEntity<S>
    {
        public IEnumerable<IRequirement<E, S>> Requirements { get; }
    }
}