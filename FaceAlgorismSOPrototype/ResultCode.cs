using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceAlgorismSOPrototype
{
    public enum ResultCode
    {
        ERROR_INVALID = 0,
        SUCCESS,
        ERROR_EMPTY_IMAGE,
        ERROR_FACE_NONE,
        ERROR_LANDMARK_NONE,
        ERROR_LANDMARK_NOTMATCH,
        ERROR_EMBEDDING_NONE,
        ERROR_EMBEDDING_BUFFER_NONE,
        ERROR_PENDING_INIT,
        ERROR_UNKNOWN
    }
}
