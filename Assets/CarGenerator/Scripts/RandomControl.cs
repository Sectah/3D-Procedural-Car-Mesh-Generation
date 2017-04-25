using UnityEngine;
using System;

public class RandomControl : MonoBehaviour {

	[Space]
	[Header("CHANGE VALUES           X = MIN, Y = MAX")]
	[Space]
	[Header("Basic")]
	public Basic basicModel;
	[Space]
	[Header("Classic")]
	public Classic classicModel;
	[Space]
	[Header("Van")]
	public Van vanModel;
}

#region Basic
[Serializable]
public class Basic {

	public Vector2 Width = new Vector2 (3.75f, 7.35f);
	public BasicGrill Grill;
	public BasicGrillToBonnet GrillToBonnet;
	public BasicBonnet Bonnet;
	public BasicBonnetToWindscreen BonnetToWindscreen;
	public BasicWindscreen Windscreen;
	public BasicRoof Roof;
	public BasicBackWindow RearWindow;
	public BasicRearPanel RearPanel;
	public BasicBackend Backend;
}

[Serializable]
public class BasicGrill {
	public Vector2 Height = new Vector2 (0.25f, 1f);
	public Vector2 Depth = new Vector2 (0f, 0.5f);
}

[Serializable]
public class BasicGrillToBonnet {
	public Vector2 Height = new Vector2 (0.5f, 1f);
	public Vector2 Depth = new Vector2 (1f, 1.5f);
}

[Serializable]
public class BasicBonnet {
	public Vector2 Height = new Vector2 (0.1f, 0.3f);
	public Vector2 Depth = new Vector2(0.5f, 2f);
}

[Serializable]
public class BasicBonnetToWindscreen {
	public Vector2 Height = new Vector2 (-0.2f, 0.2f);
	public Vector2 Depth = new Vector2(0.25f, 0.5f);
}

[Serializable]
public class BasicWindscreen {
	public Vector2 Height = new Vector2 (1.5f, 2.0f);
	public Vector2 Depth = new Vector2(0.5f, 1.5f);
	public Vector2 Rim = new Vector2(0.05f, 0.15f);
}

[Serializable]
public class BasicRoof {
	public Vector2 Height = new Vector2 (-0.25f, 0.25f);
	public Vector2 Depth = new Vector2(2.5f, 6.25f);
}

[Serializable]
public class BasicBackWindow {
	public string Height = "Height is matched to top of bonnet";
	public Vector2 Depth = new Vector2 (1.0f, 2.25f);
	public Vector2 Rim = new Vector2(0.05f, 0.15f);
}

[Serializable]
public class BasicRearPanel {
	public Vector2 Height = new Vector2 (0.1f, 0.3f);
	public Vector2 Depth = new Vector2(0.2f, 2f);
}

[Serializable]
public class BasicBackend {
	public Vector2 Height = new Vector2 (0.02f, 0.2f);
	public Vector2 Depth = new Vector2(0.2f, 0.75f);
}
#endregion

#region Classic
[Serializable]
public class Classic {
	public Vector2 Width = new Vector2(5.75f, 8.25f);
	public ClassicFrontBumper FrontBumper;
	public ClassicInwardFrontBumper InwardFrontBumper;
	public ClassicUpwardFrontBumper UpwardFrontBumper;
	public ClassicBonnetPartA BonnetPartA;
	public ClassicBonnetPartB BonnetPartB;
	public ClassicWindscreen Windscreen;
	public ClassicRearBody RearBody;
	public ClassicRearTop RearTop;
	public ClassicRearBottom RearBottom;
}

[Serializable]
public class ClassicFrontBumper {
	public Vector2 Height = new Vector2 (0.07f, 0.78f);
}

[Serializable]
public class ClassicInwardFrontBumper {
	public Vector2 Height = new Vector2 (0f, 0.5f);
	public Vector2 Depth = new Vector2 (0.05f, 0.75f);
}

[Serializable]
public class ClassicUpwardFrontBumper {
	public Vector2 Height = new Vector2 (0.47f, 1.56f);
}

[Serializable]
public class ClassicBonnetPartA {
	public Vector2 Height = new Vector2 (-0.3f, 0.3f);
	public Vector2 Depth = new Vector2 (1.87f, 2.78f);
}

[Serializable]
public class ClassicBonnetPartB {
	public Vector2 Height = new Vector2 (-0.1f, -0.3f);
	public Vector2 Depth = new Vector2 (2.25f, 3.75f);
}

[Serializable]
public class ClassicWindscreen {
	public Vector2 Height = new Vector2 (2.0f, 2.75f);
	public Vector2 Depth = new Vector2 (0.5f, 3.5f);
	public Vector2 Rim = new Vector2 (0.1f, 0.2f);
	[Tooltip("How much the top of the windscreen can bend inwards")] public Vector2 TopOffset = new Vector2 (0f, 0.5f);
}

[Serializable]
public class ClassicRearBody {
	public Vector2 Depth = new Vector2 (1.75f, 4.25f);
	public Vector2 Gap = new Vector2 (2.5f, 6.75f);
}

[Serializable]
public class ClassicRearTop {
 	public string Height = "Height is same as front bumper position";
	public Vector2 Depth = new Vector2 (0.50f, 1.75f);
}

[Serializable]
public class ClassicRearBottom {
	public string Height = "Height is same as front bumper position";
	public Vector2 Depth = new Vector2 (-0.50f, -1.75f);
}
#endregion

#region Van
[Serializable]
public class Van {
	public Vector2 Width = new Vector2(5.75f, 8.25f);
	public VanBumperUnderside BumperUnderside;
	public VanBumperStraight BumperStraight;
	public VanGrill Grill;
	public VanGrillSlant GrillSlant;
	public VanBonnet Bonnet;
	public VanWindscreen Windscreen;
	public VanRoof Roof;
	public VanRearSlant RearSlant;
	public VanRearBumper RearBumper;
}

[Serializable]
public class VanBumperUnderside {
	public Vector2 Height = new Vector2(0.3f, 0.4f);
	public Vector2 Depth = new Vector2(-0.7f, -0.1f);
}

[Serializable]
public class VanBumperStraight {
	public Vector2 Height = new Vector2(0.37f, 0.85f);
}

[Serializable]
public class VanGrill {
	public Vector2 Height = new Vector2(1f, 2.65f);
}

[Serializable]
public class VanGrillSlant {
	public Vector2 Height = new Vector2(0.1f, 0.4f);
	public Vector2 Depth = new Vector2(0.07f, 0.47f);
}

[Serializable]
public class VanBonnet {
	public Vector2 Depth = new Vector2(1.9f, 2.8f);
}

[Serializable]
public class VanWindscreen {
	public Vector2 Height = new Vector2(1.76f, 3.23f);
	public Vector2 Depth = new Vector2(0.2f, 1.85f);
	public Vector2 Rim = new Vector2(0.1f, 0.2f);
}

[Serializable]
public class VanRoof {
	public Vector2 Depth = new Vector2(8.3f, 10.8f);
}

[Serializable]
public class VanRearSlant {
	public Vector2 Height = new Vector2(-0.7f, -0.3f);
	public Vector2 Depth = new Vector2(0.1f, 0.3f);
}

[Serializable]
public class VanRearBumper {
	public Vector2 Depth = new Vector2(0.1f, 0.2f);
}
#endregion