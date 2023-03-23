using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CaptainCoder.SkillTree.UnityEngine.Demo
{
    public interface IPlayerCharacter : ISkilledEntity<SkillData>, ISkillChanged
    {
        public int Level { get; }
        public int SkillPoints { get; }
        public Alignment Alignment { get; }

        /// <summary>
        /// Attempts to add the specified <paramref name="skillNode"/> to this entity. Returns
        /// true if the entity has the skill at the end of this call. If the entity already
        /// had the skill, the entity is not modified.
        /// </summary>
        public bool AcquireSkill(ISkillNode<IPlayerCharacter, SkillData> skillNode);
    }
}
