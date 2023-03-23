# RightWritingEmail

During this learning task was created a program which finding all the right writing email addresses in the textfile.

Examples of addresses is located in the TextFileWithMails.txt file in the Files folder.
Program use a FileReader class (which implements IFileReader interface) for the reading expressions from file.

After this reading follows the checking of right writing in the StringHandler class. At the exit program has a list of right 
writing email addresses, also exists the option of creating additional list with addresses, which didn't pass the check.

A correctly written address according to the program:
- has a "@" symbol,
- consists of local part (behind "@" symbol) and domain part (after "@" symbol) - each of them has a length not greater 
than standart length (the meaning of the standart length fixed as a const),
- both of this parts have to allowed symbols only (list of not allowed symbols fixed as a readonly array of chars),
- the domain part isn't a reserved domain (the list of reserved domains fixed as a readonly array of strings),
- the domain part doesn't have an underscore,
- if the domain part has a hyphen, this hyphen must be used in a legitimate way,
- local part can be a quote (in quotation marks) or no,
- when the local part is a quote is allowed to the not allowed symbols (as a quote),
- when the local part has a dot, this dot must be used correctly.
