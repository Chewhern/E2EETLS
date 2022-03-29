# E2EETLS
A C# client application that uses end to end encryption to transfer private or confidential files.

## Application Notice
This application runs on .Net 5 Winforms. If you can't run the software, you'll need to refer to the bottom section here.\
https://github.com/Chewhern/PriSec_General \
Simply check on the **Version .Net 5 and above**

## License notice
If you are not using it for commercial purpose, the license will act like MIT license.\
However if you are using it for commercial purpose, the license will act like GNU Affero General Public Lisense.

## Symmetric encryption algorithms
There're 3 symmetric encryption algorithms which are XSalsa20Poly1305, XChaCha20Poly1305 and hardware accelerated AES256GCM,
the code for XSalsa20Poly1305 and XChaCha20Poly1305 were tested.

I can't test the hardware accelerated AES256GCM, I can't guarantee the code will work.

## KDF Rachet
In signal's x3DH protocol, there're 2 rachets which are KDF rachet which serves as forward secrecy and DHKX rachet which serves
as future perfected forward secrecy.

The KDF rachet might not be perfect as it's not simply possible for me to create a synchronisation of the KDF rachet count on
both sender's and recipient's side respectively.

The KDF rachet that I implemented also have user experience issues.

## DHKX Rachet
There're no possible ways to determine the agreed deletion time on both sender's and recipient's side. If anyone would like
to achieve future perfected forward secrecy, they will need to delete the DHKX's data and generate new one by their own.
