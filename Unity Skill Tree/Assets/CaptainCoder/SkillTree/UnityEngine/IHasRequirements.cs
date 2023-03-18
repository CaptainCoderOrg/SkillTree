using System.Collections.Generic;
using UnityEngine;
namespace CaptainCoder.SkillTree.UnityEngine
{

    public interface IHasRequirements<E, S> where E : ISkilledEntity<S>
    {
        public IEnumerable<IRequirement<E, S>> Requirements => new IRequirement<E, S>[0];
    }
}