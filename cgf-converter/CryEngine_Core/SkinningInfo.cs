﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CgfConverter;

namespace CgfConverter.CryEngine_Core
{
    public class SkinningInfo
    {
        /// <summary>
        /// If there is skinning info in the model, set to true.
        /// </summary>
        public bool HasSkinningInfo { get; set; }
        /// <summary>
        /// BoneEntities are the list of the bones in the object.  Contains the info to find each of the necessary skinning components.
        /// </summary>
        public List<BoneEntity> BoneEntities { get; set; }
        public List<CompiledBone> CompiledBones { get; set; }
        public List<DirectionalBlends> LookDirectionBlends { get; set; }
        public List<PhysicalProxy> PhysicalBoneMeshes { get; set; }           // Collision proxies
        public List<MorphTargets> MorphTargets { get; set; }
        public List<TFace> IntFaces { get; set; }
        public List<IntSkinVertex> IntVertices { get; set; }
        public List<UInt16> Ext2IntMap { get; set; }
        public List<MeshCollisionInfo> Collisions { get; set; }
        public List<MeshBoneMapping> BoneMapping { get; set; }                  // Bone Mappings are read from a Datastream chunk
        public bool HasBoneMapDatastream { get; internal set; }



        /// <summary>
        /// Given a bone name, get the Controller ID.
        /// </summary>
        /// <param name="jointName">Bone name</param>
        /// <returns>Controller ID of the bone.</returns>
        public int GetJointIDByName(string jointName)
        {
            int numJoints = CompiledBones.Count;
            for (int i = 0; i < numJoints; i++)
            {
                if (string.Equals(CompiledBones[i], jointName))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Given a joint ID, get the name of the bone.
        /// </summary>
        /// <param name="jointID">ID of the bone.</param>
        /// <returns>Name of the bone.</returns>
        public string GetJointNameByID(int jointID)
        {
            int numJoints = CompiledBones.Count;
            if (jointID >= 0 && jointID < numJoints)
            {
                return CompiledBones[jointID].boneName;
            }
            return string.Empty;        // Invalid bone ID
        }

    }
}
