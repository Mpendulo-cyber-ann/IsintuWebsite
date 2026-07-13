This folder is where your attire photos go.

I haven't included actual photos here since I can't source or generate real
product photography for you, but the code is already wired up to look for
these exact filenames (set in Migrations/Configuration.cs):

- zulu-attire-main.jpg          (full men's Zulu regalia set)
- zulu-isicholo.jpg             (traditional woven headgear)
- zulu-beaded-necklace.jpg      (layered beaded necklace set)
- zulu-womens-dress.jpg         (women's traditional dress)
- zulu-shield-spear.jpg         (shield & spear prop set)

Just drop your own photos into this folder using these names, or update the
ImageUrl values in Configuration.cs if you'd rather use different filenames.
Recommended size: roughly 800x800px so the grid and details page stay sharp.
