using System;
using UnityEngine.Events;

[Serializable]
public class VuMarkNumericHandler : UnityEvent<ulong> { }

[Serializable]
public class VuMarkIdHandler : UnityEvent<string> { }

[Serializable]
public class VuMarkBytesHandler : UnityEvent<byte[]> { }