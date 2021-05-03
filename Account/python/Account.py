from enum import IntFlag, auto

class Access(IntFlag):
    NONE = 0
    DELETE = auto()  # 1
    PUBLISH = auto() # 2
    SUBMIT = auto()  # 4
    COMMENT = auto() # 8
    MODIFY = auto()  # 16
    WRITER = SUBMIT | MODIFY # 20
    EDITOR = DELETE | PUBLISH | COMMENT # 11
    OWNER = WRITER | EDITOR # 31

# Show Values for Flags
print(list(Access))

# BaseCase_WriterDelete
print("Expected: ", "False","| Result: ",Access.DELETE in Access.WRITER)

# Owner_has_all_base_permissions
print("Expected: ", "True","| Result: ",Access.DELETE in Access.OWNER and
    Access.PUBLISH in Access.OWNER and Access.SUBMIT  in Access.OWNER and
    Access.COMMENT in Access.OWNER and Access.COMMENT in Access.OWNER )

# Owner_has_Writer_and_Editor
print("Expected: ", "True","| Result: ",Access.WRITER in Access.OWNER and
    Access.EDITOR in Access.OWNER )

# Writer_has_Submit_Modify
print("Expected: ", "True","| Result: ",Access.SUBMIT in Access.WRITER and
    Access.MODIFY in Access.WRITER )

# Editor_has_delete_publish_comment
print("Expected: ", "True","| Result: ",Access.DELETE in Access.EDITOR and
    Access.PUBLISH in Access.EDITOR and Access.COMMENT in Access.EDITOR )

