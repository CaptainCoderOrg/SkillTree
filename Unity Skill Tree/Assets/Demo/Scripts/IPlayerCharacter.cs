using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CaptainCoder.SkillTree.UnityEngine.Demo
{
    public interface ISkilledEntity2<S> : ISkilledEntity<S> where S : ISkill
    {
        public new HashSet<ISkill> Skills => ((ISkilledEntity2<S>)this).Skills.Select(s => (ISkill)s).ToHashSet();
    }
    public interface IPlayerCharacter : ISkilledEntity2<SkillData>
    {
        public int Level { get; }
        public int SkillPoints { get; }
        public Alignment Alignment { get; }
    }

    public class PlayerCharacter : IPlayerCharacter
    {
        public int Level => throw new System.NotImplementedException();

        public int SkillPoints => throw new System.NotImplementedException();

        public Alignment Alignment => throw new System.NotImplementedException();

        public HashSet<SkillData> Skills => null;
    }
}
