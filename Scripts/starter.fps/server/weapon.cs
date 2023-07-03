$WeaponSlot = 0;
function Weapon::onUse(%data, %obj)
{
	if (%obj.getMountedImage($WeaponSlot) != %data.image.getId())
	{
		ServerPlay3D(WeaponUseSound, %obj.getTransform());
		%obj.mountImage(%data.image, $WeaponSlot);
		if (%obj.client)
		{
			messageClient(%obj.client, 'MsgWeaponUsed', 'Weapon selected');
		}
	}
}

function Weapon::onPickup(%this, %obj, %shape, %amount)
{
	echo("==Weapon pris" SPC %this);
	if (Parent::onPickup(%this, %obj, %shape, %amount))
	{
		ServerPlay3D(WeaponPickupSound, %obj.getTransform());
		if (%shape.getClassName() $= "Player" && %shape.getMountedImage($WeaponSlot) == 0.0)
		{
			%shape.use(%this);
		}
	}
}

function Weapon::onInventory(%this, %obj, %amount)
{
	%slot = %obj.getMountSlot(%this.image);
	if (!%amount && %obj.getMountSlot(%this.image) != -1.0)
	{
		%obj.unmountImage(%slot);
	}
}

function WeaponImage::onMount(%this, %obj, %slot)
{
	if (%obj.getInventory(%this.ammo))
	{
		%obj.setImageAmmo(%slot, 1);
	}
}

function ammo::onPickup(%this, %obj, %shape, %amount)
{
	echo("==Ammo pris" SPC %this);
	if (Parent::onPickup(%this, %obj, %shape, %amount))
	{
		ServerPlay3D(AmmoPickupSound, %obj.getTransform());
	}
}

function ammo::onInventory(%this, %obj, %amount)
{
	%i = 0;
	while(%i < 8.0)
	{
		%image = %obj.getMountedImage(%i);
		if (%obj.getMountedImage(%i) > 0.0)
		{
			if (isObject(%image.ammo) && %image.ammo.getId() == %this.getId())
			{
				%obj.setImageAmmo(%i, %amount != 0.0);
			}
		}
		%i = %i + 1.0;
	}
}

