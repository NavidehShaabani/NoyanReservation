USE [Tower]
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'LastLoginAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'PhoneVerified'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'AvatarUrl'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'BirthDate'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Gender'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'NationalId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'LastName'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'FirstName'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Mobile'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'PasswordHash'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Username'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'ExpiresAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'AssignedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'RoleId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'UserRoleId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'Notes'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'EndDate'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'StartDate'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'RelationshipType'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'UnitId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'UserResidencyId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'Notes'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'EmergencyContactRelation'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'EmergencyContactMobile'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'EmergencyContactName'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'UserAddress'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'UserPostalCode'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'LandlinePhone'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'BirthPlace'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'FatherName'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'UserProfileId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'RequestIp'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'IsBlocked'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'IsUsed'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'MaxAttempts'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'AttemptCount'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'VerifiedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'ExpiresAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'OtpPurpose'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'OtpCode'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'Mobile'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'OtpRequestId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'UnitDescription'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'Bedrooms'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'Area'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'FloorNumber'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'UnitNumber'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'BuildingId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'UnitId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'IsReservable'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'SpaceDesc'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'Area'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'Capacity'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'SpaceType'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'SpaceName'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'ParentSpaceId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'BuildingId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'OrgId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'SpaceId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Roles', @level2type=N'COLUMN',@level2name=N'RoleDescription'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Roles', @level2type=N'COLUMN',@level2name=N'RoleName'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Roles', @level2type=N'COLUMN',@level2name=N'RoleId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'PermissionLevel'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'MenuId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'RoleId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'RoleMenuId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'OrgDesc'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'GeoId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'OrgType'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'OrgName'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'OrgId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'IsVisible'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'MenuDescription'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'SortOrder'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'Icon'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'MenuUrl'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'MenuId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Geo'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Geo', @level2type=N'COLUMN',@level2name=N'GeoPath'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Geo', @level2type=N'COLUMN',@level2name=N'PL5'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Geo', @level2type=N'COLUMN',@level2name=N'PL4'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Geo', @level2type=N'COLUMN',@level2name=N'PL3'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Geo', @level2type=N'COLUMN',@level2name=N'PL2'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Geo', @level2type=N'COLUMN',@level2name=N'PL1'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Geo', @level2type=N'COLUMN',@level2name=N'ParantId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Geo', @level2type=N'COLUMN',@level2name=N'GeoName'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Geo', @level2type=N'COLUMN',@level2name=N'GeoId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'EmployeeTypeDesc'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'EmployeeTypeName'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'EmployeeTypeId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'EmployeesDesc'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'ShebaNumber'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'BankAccountNumber'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'BankCardNumber'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'BankName'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'HourlyRate'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'BaseSalary'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'EndDate'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'HireDate'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'EmploymentType'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'EmployeeTypeId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'OrgId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'EmployeeId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'EmployeeAssignmentDesc'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'ShiftName'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'EndDate'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'StartDate'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'SpaceId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'BuildingId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'OrgId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'EmployeeId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'EmployeeAssignmentId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'OrgId'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'BuildingDescription'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'BuildingAddress'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'BuildingName'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'BuildingId'
GO
/****** Object:  StoredProcedure [dbo].[UsersSignup]    Script Date: 9/11/2026 7:47:01 PM ******/
DROP PROCEDURE [dbo].[UsersSignup]
GO
/****** Object:  StoredProcedure [dbo].[UsersOtpVerify]    Script Date: 9/11/2026 7:47:01 PM ******/
DROP PROCEDURE [dbo].[UsersOtpVerify]
GO
/****** Object:  StoredProcedure [dbo].[UsersCompleteProfile]    Script Date: 9/11/2026 7:47:01 PM ******/
DROP PROCEDURE [dbo].[UsersCompleteProfile]
GO
/****** Object:  StoredProcedure [dbo].[UserLogin]    Script Date: 9/11/2026 7:47:01 PM ******/
DROP PROCEDURE [dbo].[UserLogin]
GO
/****** Object:  StoredProcedure [dbo].[UnitsGet]    Script Date: 9/11/2026 7:47:01 PM ******/
DROP PROCEDURE [dbo].[UnitsGet]
GO
/****** Object:  StoredProcedure [dbo].[UnitsEdit]    Script Date: 9/11/2026 7:47:01 PM ******/
DROP PROCEDURE [dbo].[UnitsEdit]
GO
/****** Object:  StoredProcedure [dbo].[UnitsDel]    Script Date: 9/11/2026 7:47:01 PM ******/
DROP PROCEDURE [dbo].[UnitsDel]
GO
/****** Object:  StoredProcedure [dbo].[UnitsAdd]    Script Date: 9/11/2026 7:47:01 PM ******/
DROP PROCEDURE [dbo].[UnitsAdd]
GO
/****** Object:  StoredProcedure [dbo].[OrganizationsGet]    Script Date: 9/11/2026 7:47:01 PM ******/
DROP PROCEDURE [dbo].[OrganizationsGet]
GO
/****** Object:  StoredProcedure [dbo].[OrganizationsEdit]    Script Date: 9/11/2026 7:47:01 PM ******/
DROP PROCEDURE [dbo].[OrganizationsEdit]
GO
/****** Object:  StoredProcedure [dbo].[OrganizationsDel]    Script Date: 9/11/2026 7:47:01 PM ******/
DROP PROCEDURE [dbo].[OrganizationsDel]
GO
/****** Object:  StoredProcedure [dbo].[OrganizationsAdd]    Script Date: 9/11/2026 7:47:01 PM ******/
DROP PROCEDURE [dbo].[OrganizationsAdd]
GO
/****** Object:  StoredProcedure [dbo].[BuildingsGet]    Script Date: 9/11/2026 7:47:01 PM ******/
DROP PROCEDURE [dbo].[BuildingsGet]
GO
/****** Object:  StoredProcedure [dbo].[BuildingsEdit]    Script Date: 9/11/2026 7:47:01 PM ******/
DROP PROCEDURE [dbo].[BuildingsEdit]
GO
/****** Object:  StoredProcedure [dbo].[BuildingsDel]    Script Date: 9/11/2026 7:47:01 PM ******/
DROP PROCEDURE [dbo].[BuildingsDel]
GO
/****** Object:  StoredProcedure [dbo].[BuildingsAdd]    Script Date: 9/11/2026 7:47:01 PM ******/
DROP PROCEDURE [dbo].[BuildingsAdd]
GO
ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_UserRoles_Users]
GO
ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_UserRoles_Roles]
GO
ALTER TABLE [dbo].[UserResidencies] DROP CONSTRAINT [FK_UserResidencies_Users]
GO
ALTER TABLE [dbo].[UserResidencies] DROP CONSTRAINT [FK_UserResidencies_Units]
GO
ALTER TABLE [dbo].[UserProfiles] DROP CONSTRAINT [FK_UserProfiles_Users]
GO
ALTER TABLE [dbo].[UserOtpRequests] DROP CONSTRAINT [FK_UserOtpRequests_Users]
GO
ALTER TABLE [dbo].[Units] DROP CONSTRAINT [FK_Units_Buildings]
GO
ALTER TABLE [dbo].[Spaces] DROP CONSTRAINT [FK_Spaces_Parent]
GO
ALTER TABLE [dbo].[Spaces] DROP CONSTRAINT [FK_Spaces_Orgs]
GO
ALTER TABLE [dbo].[Spaces] DROP CONSTRAINT [FK_Spaces_Buildings]
GO
ALTER TABLE [dbo].[RoleMenus] DROP CONSTRAINT [FK_RoleMenus_Roles]
GO
ALTER TABLE [dbo].[RoleMenus] DROP CONSTRAINT [FK_RoleMenus_Menus]
GO
ALTER TABLE [dbo].[Organizations] DROP CONSTRAINT [FK_Organizations_Geo]
GO
ALTER TABLE [dbo].[Menus] DROP CONSTRAINT [FK_Menus_Parent]
GO
ALTER TABLE [dbo].[Geo] DROP CONSTRAINT [FK_Geo_Geo]
GO
ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_Employees_Users]
GO
ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_Employees_Types]
GO
ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_Employees_Org]
GO
ALTER TABLE [dbo].[EmployeeAssignments] DROP CONSTRAINT [FK_EmployeeAssignments_Spaces]
GO
ALTER TABLE [dbo].[EmployeeAssignments] DROP CONSTRAINT [FK_EmployeeAssignments_Org]
GO
ALTER TABLE [dbo].[EmployeeAssignments] DROP CONSTRAINT [FK_EmployeeAssignments_Employees]
GO
ALTER TABLE [dbo].[EmployeeAssignments] DROP CONSTRAINT [FK_EmployeeAssignments_Buildings]
GO
ALTER TABLE [dbo].[Buildings] DROP CONSTRAINT [FK_Buildings_Orgs]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_Users_CreatedAt]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_Users_IsActive]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_Users_PhoneVerified]
GO
ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [DF_UserRoles_CreatedAt]
GO
ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [DF_UserRoles_IsActive]
GO
ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [DF_UserRoles_AssignedAt]
GO
ALTER TABLE [dbo].[UserResidencies] DROP CONSTRAINT [DF_UserResidencies_CreatedAt]
GO
ALTER TABLE [dbo].[UserResidencies] DROP CONSTRAINT [DF_UserResidencies_IsActive]
GO
ALTER TABLE [dbo].[UserProfiles] DROP CONSTRAINT [DF_UserProfiles_CreatedAt]
GO
ALTER TABLE [dbo].[UserOtpRequests] DROP CONSTRAINT [DF_UserOtpRequests_IsBlocked]
GO
ALTER TABLE [dbo].[UserOtpRequests] DROP CONSTRAINT [DF_UserOtpRequests_IsUsed]
GO
ALTER TABLE [dbo].[UserOtpRequests] DROP CONSTRAINT [DF_UserOtpRequests_MaxAttempts]
GO
ALTER TABLE [dbo].[UserOtpRequests] DROP CONSTRAINT [DF_UserOtpRequests_AttemptCount]
GO
ALTER TABLE [dbo].[UserOtpRequests] DROP CONSTRAINT [DF_UserOtpRequests_CreatedAt]
GO
ALTER TABLE [dbo].[UserOtpRateLimits] DROP CONSTRAINT [DF_UserOtpRateLimits_DailyCount]
GO
ALTER TABLE [dbo].[UserOtpRateLimits] DROP CONSTRAINT [DF_UserOtpRateLimits_RequestCount]
GO
ALTER TABLE [dbo].[Units] DROP CONSTRAINT [DF_Units_CreatedAt]
GO
ALTER TABLE [dbo].[Units] DROP CONSTRAINT [DF_Units_IsActive]
GO
ALTER TABLE [dbo].[Spaces] DROP CONSTRAINT [DF_Spaces_CreatedAt]
GO
ALTER TABLE [dbo].[Spaces] DROP CONSTRAINT [DF_Spaces_IsActive]
GO
ALTER TABLE [dbo].[Spaces] DROP CONSTRAINT [DF_Spaces_IsReservable]
GO
ALTER TABLE [dbo].[RoleMenus] DROP CONSTRAINT [DF_RoleMenus_CreatedAt]
GO
ALTER TABLE [dbo].[RoleMenus] DROP CONSTRAINT [DF_RoleMenus_IsActive]
GO
ALTER TABLE [dbo].[RoleMenus] DROP CONSTRAINT [DF_RoleMenus_PermissionLevel]
GO
ALTER TABLE [dbo].[Organizations] DROP CONSTRAINT [DF_Orgs_CreatedAt]
GO
ALTER TABLE [dbo].[Organizations] DROP CONSTRAINT [DF_Orgs_IsActive]
GO
ALTER TABLE [dbo].[Menus] DROP CONSTRAINT [DF_Menus_CreatedAt]
GO
ALTER TABLE [dbo].[Menus] DROP CONSTRAINT [DF_Menus_IsActive]
GO
ALTER TABLE [dbo].[Menus] DROP CONSTRAINT [DF_Menus_IsVisible]
GO
ALTER TABLE [dbo].[Menus] DROP CONSTRAINT [DF_Menus_SortOrder]
GO
ALTER TABLE [dbo].[EmployeeTypes] DROP CONSTRAINT [DF_EmployeeTypes_CreatedAt]
GO
ALTER TABLE [dbo].[EmployeeTypes] DROP CONSTRAINT [DF_EmployeeTypes_IsActive]
GO
ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [DF_Employees_CreatedAt]
GO
ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [DF_Employees_IsActive]
GO
ALTER TABLE [dbo].[EmployeeAssignments] DROP CONSTRAINT [DF_EmployeeAssignments_CreatedAt]
GO
ALTER TABLE [dbo].[EmployeeAssignments] DROP CONSTRAINT [DF_EmployeeAssignments_IsActive]
GO
ALTER TABLE [dbo].[Buildings] DROP CONSTRAINT [DF_Buildings_CreatedAt]
GO
ALTER TABLE [dbo].[Buildings] DROP CONSTRAINT [DF_Buildings_IsActive]
GO
/****** Object:  Index [UQ_Users_Username]    Script Date: 9/11/2026 7:47:01 PM ******/
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [UQ_Users_Username]
GO
/****** Object:  Index [UQ_Users_NationalId]    Script Date: 9/11/2026 7:47:01 PM ******/
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [UQ_Users_NationalId]
GO
/****** Object:  Index [UQ_Users_Email]    Script Date: 9/11/2026 7:47:01 PM ******/
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [UQ_Users_Email]
GO
/****** Object:  Index [UQ_UserRoles_User_Role]    Script Date: 9/11/2026 7:47:01 PM ******/
ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [UQ_UserRoles_User_Role]
GO
/****** Object:  Index [UQ_UserProfiles_UserId]    Script Date: 9/11/2026 7:47:01 PM ******/
ALTER TABLE [dbo].[UserProfiles] DROP CONSTRAINT [UQ_UserProfiles_UserId]
GO
/****** Object:  Index [UQ_UserOtpRateLimits_Mobile]    Script Date: 9/11/2026 7:47:01 PM ******/
ALTER TABLE [dbo].[UserOtpRateLimits] DROP CONSTRAINT [UQ_UserOtpRateLimits_Mobile]
GO
/****** Object:  Index [UQ_RoleMenus_Role_Menu]    Script Date: 9/11/2026 7:47:01 PM ******/
ALTER TABLE [dbo].[RoleMenus] DROP CONSTRAINT [UQ_RoleMenus_Role_Menu]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/11/2026 7:47:01 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 9/11/2026 7:47:01 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRoles]') AND type in (N'U'))
DROP TABLE [dbo].[UserRoles]
GO
/****** Object:  Table [dbo].[UserResidencies]    Script Date: 9/11/2026 7:47:01 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserResidencies]') AND type in (N'U'))
DROP TABLE [dbo].[UserResidencies]
GO
/****** Object:  Table [dbo].[UserProfiles]    Script Date: 9/11/2026 7:47:01 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserProfiles]') AND type in (N'U'))
DROP TABLE [dbo].[UserProfiles]
GO
/****** Object:  Table [dbo].[UserOtpRequests]    Script Date: 9/11/2026 7:47:01 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserOtpRequests]') AND type in (N'U'))
DROP TABLE [dbo].[UserOtpRequests]
GO
/****** Object:  Table [dbo].[UserOtpRateLimits]    Script Date: 9/11/2026 7:47:01 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserOtpRateLimits]') AND type in (N'U'))
DROP TABLE [dbo].[UserOtpRateLimits]
GO
/****** Object:  Table [dbo].[Units]    Script Date: 9/11/2026 7:47:01 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Units]') AND type in (N'U'))
DROP TABLE [dbo].[Units]
GO
/****** Object:  Table [dbo].[Spaces]    Script Date: 9/11/2026 7:47:01 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Spaces]') AND type in (N'U'))
DROP TABLE [dbo].[Spaces]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 9/11/2026 7:47:01 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
DROP TABLE [dbo].[Roles]
GO
/****** Object:  Table [dbo].[RoleMenus]    Script Date: 9/11/2026 7:47:01 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleMenus]') AND type in (N'U'))
DROP TABLE [dbo].[RoleMenus]
GO
/****** Object:  Table [dbo].[Organizations]    Script Date: 9/11/2026 7:47:01 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Organizations]') AND type in (N'U'))
DROP TABLE [dbo].[Organizations]
GO
/****** Object:  Table [dbo].[Menus]    Script Date: 9/11/2026 7:47:01 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Menus]') AND type in (N'U'))
DROP TABLE [dbo].[Menus]
GO
/****** Object:  Table [dbo].[Geo]    Script Date: 9/11/2026 7:47:01 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Geo]') AND type in (N'U'))
DROP TABLE [dbo].[Geo]
GO
/****** Object:  Table [dbo].[EmployeeTypes]    Script Date: 9/11/2026 7:47:01 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmployeeTypes]') AND type in (N'U'))
DROP TABLE [dbo].[EmployeeTypes]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 9/11/2026 7:47:01 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees]') AND type in (N'U'))
DROP TABLE [dbo].[Employees]
GO
/****** Object:  Table [dbo].[EmployeeAssignments]    Script Date: 9/11/2026 7:47:01 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmployeeAssignments]') AND type in (N'U'))
DROP TABLE [dbo].[EmployeeAssignments]
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 9/11/2026 7:47:01 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Buildings]') AND type in (N'U'))
DROP TABLE [dbo].[Buildings]
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 9/11/2026 7:47:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buildings](
	[BuildingId] [bigint] IDENTITY(1,1) NOT NULL,
	[BuildingName] [nvarchar](150) NOT NULL,
	[BuildingAddress] [nvarchar](500) NULL,
	[BuildingDescription] [nvarchar](1000) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
	[OrgId] [bigint] NULL,
 CONSTRAINT [PK_Buildings] PRIMARY KEY CLUSTERED 
(
	[BuildingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeAssignments]    Script Date: 9/11/2026 7:47:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeAssignments](
	[EmployeeAssignmentId] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [bigint] NOT NULL,
	[OrgId] [bigint] NOT NULL,
	[BuildingId] [bigint] NULL,
	[SpaceId] [bigint] NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NULL,
	[ShiftName] [nvarchar](100) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NULL,
	[EmployeeAssignmentDesc] [nvarchar](1000) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
 CONSTRAINT [PK_EmployeeAssignments] PRIMARY KEY CLUSTERED 
(
	[EmployeeAssignmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 9/11/2026 7:47:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[OrgId] [bigint] NOT NULL,
	[EmployeeTypeId] [int] NOT NULL,
	[EmploymentType] [tinyint] NOT NULL,
	[HireDate] [date] NULL,
	[EndDate] [date] NULL,
	[BaseSalary] [decimal](18, 2) NULL,
	[HourlyRate] [decimal](18, 2) NULL,
	[BankName] [nvarchar](100) NULL,
	[BankCardNumber] [nvarchar](100) NULL,
	[BankAccountNumber] [nvarchar](100) NULL,
	[ShebaNumber] [nvarchar](50) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NULL,
	[EmployeesDesc] [nvarchar](2000) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeTypes]    Script Date: 9/11/2026 7:47:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeTypes](
	[EmployeeTypeId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeTypeName] [nvarchar](100) NOT NULL,
	[EmployeeTypeDesc] [nvarchar](500) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
 CONSTRAINT [PK_EmployeeTypes] PRIMARY KEY CLUSTERED 
(
	[EmployeeTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Geo]    Script Date: 9/11/2026 7:47:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Geo](
	[GeoId] [bigint] NOT NULL,
	[GeoName] [nvarchar](300) NOT NULL,
	[ParantId] [bigint] NULL,
	[PL1] [bigint] NULL,
	[PL2] [bigint] NULL,
	[PL3] [bigint] NULL,
	[PL4] [bigint] NULL,
	[PL5] [bigint] NULL,
	[GeoPath] [nchar](10) NULL,
 CONSTRAINT [PK_Geo] PRIMARY KEY CLUSTERED 
(
	[GeoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menus]    Script Date: 9/11/2026 7:47:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menus](
	[MenuId] [bigint] IDENTITY(1,1) NOT NULL,
	[ParentId] [bigint] NULL,
	[Title] [nvarchar](150) NOT NULL,
	[MenuUrl] [nvarchar](500) NULL,
	[Icon] [nvarchar](100) NULL,
	[SortOrder] [int] NOT NULL,
	[MenuDescription] [nvarchar](1000) NULL,
	[IsVisible] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
 CONSTRAINT [PK_Menus] PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organizations]    Script Date: 9/11/2026 7:47:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organizations](
	[OrgId] [bigint] IDENTITY(1,1) NOT NULL,
	[OrgName] [nvarchar](200) NOT NULL,
	[OrgType] [tinyint] NOT NULL,
	[GeoId] [bigint] NOT NULL,
	[OrgDesc] [nvarchar](1000) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
 CONSTRAINT [PK_Orgs] PRIMARY KEY CLUSTERED 
(
	[OrgId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleMenus]    Script Date: 9/11/2026 7:47:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMenus](
	[RoleMenuId] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[MenuId] [bigint] NOT NULL,
	[PermissionLevel] [tinyint] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
 CONSTRAINT [PK_RoleMenus] PRIMARY KEY CLUSTERED 
(
	[RoleMenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 9/11/2026 7:47:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](100) NOT NULL,
	[RoleDescription] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Spaces]    Script Date: 9/11/2026 7:47:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Spaces](
	[SpaceId] [bigint] IDENTITY(1,1) NOT NULL,
	[OrgId] [bigint] NOT NULL,
	[BuildingId] [bigint] NULL,
	[ParentSpaceId] [bigint] NULL,
	[SpaceName] [nvarchar](200) NOT NULL,
	[SpaceType] [tinyint] NOT NULL,
	[Capacity] [int] NULL,
	[Area] [decimal](10, 2) NULL,
	[SpaceDesc] [nvarchar](1000) NULL,
	[IsReservable] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
 CONSTRAINT [PK_Spaces] PRIMARY KEY CLUSTERED 
(
	[SpaceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Units]    Script Date: 9/11/2026 7:47:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Units](
	[UnitId] [bigint] IDENTITY(1,1) NOT NULL,
	[BuildingId] [bigint] NOT NULL,
	[UnitNumber] [nvarchar](50) NOT NULL,
	[FloorNumber] [int] NULL,
	[Area] [decimal](10, 2) NULL,
	[Bedrooms] [tinyint] NULL,
	[UnitDescription] [nvarchar](1000) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
 CONSTRAINT [PK_Units] PRIMARY KEY CLUSTERED 
(
	[UnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOtpRateLimits]    Script Date: 9/11/2026 7:47:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOtpRateLimits](
	[RateLimitId] [bigint] IDENTITY(1,1) NOT NULL,
	[Mobile] [nvarchar](30) NOT NULL,
	[WindowStart] [datetime2](0) NOT NULL,
	[RequestCount] [int] NOT NULL,
	[DailyDate] [date] NOT NULL,
	[DailyCount] [int] NOT NULL,
	[BlockedUntil] [datetime2](0) NULL,
	[LastRequestAt] [datetime2](0) NULL,
 CONSTRAINT [PK_UserOtpRateLimits] PRIMARY KEY CLUSTERED 
(
	[RateLimitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOtpRequests]    Script Date: 9/11/2026 7:47:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOtpRequests](
	[OtpRequestId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[Mobile] [nvarchar](30) NOT NULL,
	[OtpCode] [nvarchar](30) NULL,
	[OtpPurpose] [int] NOT NULL,
	[CreatedAt] [datetime2](0) NOT NULL,
	[ExpiresAt] [datetime2](0) NOT NULL,
	[VerifiedAt] [datetime2](0) NULL,
	[AttemptCount] [int] NOT NULL,
	[MaxAttempts] [int] NOT NULL,
	[IsUsed] [bit] NOT NULL,
	[IsBlocked] [bit] NOT NULL,
	[RequestIp] [nvarchar](50) NULL,
	[UserAgent] [nvarchar](500) NULL,
 CONSTRAINT [PK_UserOtpRequests] PRIMARY KEY CLUSTERED 
(
	[OtpRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserProfiles]    Script Date: 9/11/2026 7:47:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfiles](
	[UserProfileId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[FatherName] [nvarchar](100) NULL,
	[BirthPlace] [nvarchar](150) NULL,
	[LandlinePhone] [nvarchar](30) NULL,
	[UserPostalCode] [nvarchar](20) NULL,
	[UserAddress] [nvarchar](500) NULL,
	[EmergencyContactName] [nvarchar](200) NULL,
	[EmergencyContactMobile] [nvarchar](30) NULL,
	[EmergencyContactRelation] [nvarchar](100) NULL,
	[Notes] [nvarchar](2000) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
 CONSTRAINT [PK_UserProfiles] PRIMARY KEY CLUSTERED 
(
	[UserProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserResidencies]    Script Date: 9/11/2026 7:47:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserResidencies](
	[UserResidencyId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[UnitId] [bigint] NOT NULL,
	[RelationshipType] [tinyint] NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NULL,
	[Notes] [nvarchar](1000) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
 CONSTRAINT [PK_UserResidencies] PRIMARY KEY CLUSTERED 
(
	[UserResidencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 9/11/2026 7:47:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserRoleId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[AssignedAt] [datetime] NOT NULL,
	[ExpiresAt] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
	[Notes] [nvarchar](1000) NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/11/2026 7:47:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](100) NULL,
	[PasswordHash] [nvarchar](500) NULL,
	[Email] [nvarchar](150) NULL,
	[Mobile] [nvarchar](30) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[NationalId] [nvarchar](10) NULL,
	[Gender] [int] NOT NULL,
	[BirthDate] [datetime] NULL,
	[AvatarUrl] [nvarchar](500) NULL,
	[PhoneVerified] [bit] NOT NULL,
	[LastLoginAt] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserCreater] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[UserUpdater] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Buildings] ON 
GO
INSERT [dbo].[Buildings] ([BuildingId], [BuildingName], [BuildingAddress], [BuildingDescription], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater], [OrgId]) VALUES (1, N'برج بوستان', N'تهران، منطقه ۱، خیابان نمونه، پلاک ۱۰۰', N'برج مسکونی بوستان با امکانات رفاهی و باشگاه ورزشی اختصاصی', 1, NULL, CAST(N'2026-09-01T17:22:05.297' AS DateTime), NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Buildings] OFF
GO
SET IDENTITY_INSERT [dbo].[Menus] ON 
GO
INSERT [dbo].[Menus] ([MenuId], [ParentId], [Title], [MenuUrl], [Icon], [SortOrder], [MenuDescription], [IsVisible], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (1, NULL, N'داشبورد', N'/dashboard', N'dashboard', 1, N'صفحه اصلی سامانه', 1, 1, NULL, CAST(N'2026-09-01T17:22:05.383' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Menus] ([MenuId], [ParentId], [Title], [MenuUrl], [Icon], [SortOrder], [MenuDescription], [IsVisible], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (2, NULL, N'مدیریت کاربران', N'/users', N'users', 2, N'مدیریت مالکین، ساکنین، مهمانان و اعضای خارجی', 1, 1, NULL, CAST(N'2026-09-01T17:22:05.387' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Menus] ([MenuId], [ParentId], [Title], [MenuUrl], [Icon], [SortOrder], [MenuDescription], [IsVisible], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (3, NULL, N'مدیریت نقش‌ها', N'/roles', N'roles', 3, N'مدیریت نقش‌های سامانه', 1, 1, NULL, CAST(N'2026-09-01T17:22:05.390' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Menus] ([MenuId], [ParentId], [Title], [MenuUrl], [Icon], [SortOrder], [MenuDescription], [IsVisible], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (4, NULL, N'مدیریت دسترسی‌ها', N'/permissions', N'lock', 4, N'مدیریت دسترسی نقش‌ها به منوهای سامانه', 1, 1, NULL, CAST(N'2026-09-01T17:22:05.390' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Menus] ([MenuId], [ParentId], [Title], [MenuUrl], [Icon], [SortOrder], [MenuDescription], [IsVisible], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (5, NULL, N'ساختمان', N'/building', N'building', 5, N'مدیریت ساختمان برج', 1, 1, NULL, CAST(N'2026-09-01T17:22:05.393' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Menus] ([MenuId], [ParentId], [Title], [MenuUrl], [Icon], [SortOrder], [MenuDescription], [IsVisible], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (6, NULL, N'واحدها', N'/units', N'home', 6, N'مدیریت واحدهای ساختمان', 1, 1, NULL, CAST(N'2026-09-01T17:22:05.397' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Menus] ([MenuId], [ParentId], [Title], [MenuUrl], [Icon], [SortOrder], [MenuDescription], [IsVisible], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (7, NULL, N'باشگاه ورزشی', N'/club', N'fitness_center', 7, N'مدیریت باشگاه ورزشی برج', 1, 1, NULL, CAST(N'2026-09-01T17:22:05.397' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Menus] ([MenuId], [ParentId], [Title], [MenuUrl], [Icon], [SortOrder], [MenuDescription], [IsVisible], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (8, NULL, N'رزروها', N'/reservations', N'calendar', 8, N'مدیریت رزروهای باشگاه', 1, 1, NULL, CAST(N'2026-09-01T17:22:05.400' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Menus] ([MenuId], [ParentId], [Title], [MenuUrl], [Icon], [SortOrder], [MenuDescription], [IsVisible], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (9, NULL, N'شارژ ساختمان', N'/charges', N'account_balance_wallet', 9, N'مدیریت شارژ واحدها', 1, 1, NULL, CAST(N'2026-09-01T17:22:05.400' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Menus] ([MenuId], [ParentId], [Title], [MenuUrl], [Icon], [SortOrder], [MenuDescription], [IsVisible], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (10, NULL, N'پرداخت‌ها', N'/payments', N'payment', 10, N'مدیریت پرداخت‌ها و تراکنش‌های مالی', 1, 1, NULL, CAST(N'2026-09-01T17:22:05.403' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Menus] ([MenuId], [ParentId], [Title], [MenuUrl], [Icon], [SortOrder], [MenuDescription], [IsVisible], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (11, NULL, N'گزارش‌ها', N'/reports', N'report', 11, N'گزارش‌های مدیریتی و مالی', 1, 1, NULL, CAST(N'2026-09-01T17:22:05.403' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Menus] ([MenuId], [ParentId], [Title], [MenuUrl], [Icon], [SortOrder], [MenuDescription], [IsVisible], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (12, NULL, N'تنظیمات', N'/settings', N'settings', 12, N'تنظیمات عمومی سامانه', 1, 1, NULL, CAST(N'2026-09-01T17:22:05.407' AS DateTime), NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Menus] OFF
GO
SET IDENTITY_INSERT [dbo].[RoleMenus] ON 
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (1, 1, 1, 3, 1, NULL, CAST(N'2026-09-01T17:22:05.713' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (2, 1, 2, 3, 1, NULL, CAST(N'2026-09-01T17:22:05.713' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (3, 1, 3, 3, 1, NULL, CAST(N'2026-09-01T17:22:05.713' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (4, 1, 4, 3, 1, NULL, CAST(N'2026-09-01T17:22:05.713' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (5, 1, 5, 3, 1, NULL, CAST(N'2026-09-01T17:22:05.713' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (6, 1, 6, 3, 1, NULL, CAST(N'2026-09-01T17:22:05.713' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (7, 1, 7, 3, 1, NULL, CAST(N'2026-09-01T17:22:05.713' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (8, 1, 8, 3, 1, NULL, CAST(N'2026-09-01T17:22:05.713' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (9, 1, 9, 3, 1, NULL, CAST(N'2026-09-01T17:22:05.713' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (10, 1, 10, 3, 1, NULL, CAST(N'2026-09-01T17:22:05.713' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (11, 1, 11, 3, 1, NULL, CAST(N'2026-09-01T17:22:05.713' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (12, 1, 12, 3, 1, NULL, CAST(N'2026-09-01T17:22:05.713' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (13, 2, 1, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.727' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (14, 2, 2, 1, 1, NULL, CAST(N'2026-09-01T17:22:05.727' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (15, 2, 3, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.727' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (16, 2, 4, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.727' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (17, 2, 5, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.727' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (18, 2, 6, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.727' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (19, 2, 7, 3, 1, NULL, CAST(N'2026-09-01T17:22:05.727' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (20, 2, 8, 3, 1, NULL, CAST(N'2026-09-01T17:22:05.727' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (21, 2, 9, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.727' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (22, 2, 10, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.727' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (23, 2, 11, 1, 1, NULL, CAST(N'2026-09-01T17:22:05.727' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (24, 2, 12, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.727' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (25, 3, 1, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.750' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (26, 3, 2, 1, 1, NULL, CAST(N'2026-09-01T17:22:05.750' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (27, 3, 3, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.750' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (28, 3, 4, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.750' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (29, 3, 5, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.750' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (30, 3, 6, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.750' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (31, 3, 7, 1, 1, NULL, CAST(N'2026-09-01T17:22:05.750' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (32, 3, 8, 2, 1, NULL, CAST(N'2026-09-01T17:22:05.750' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (33, 3, 9, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.750' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (34, 3, 10, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.750' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (35, 3, 11, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.750' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (36, 3, 12, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.750' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (37, 4, 1, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.760' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (38, 4, 2, 3, 1, NULL, CAST(N'2026-09-01T17:22:05.760' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (39, 4, 3, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.760' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (40, 4, 4, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.760' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (41, 4, 5, 3, 1, NULL, CAST(N'2026-09-01T17:22:05.760' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (42, 4, 6, 3, 1, NULL, CAST(N'2026-09-01T17:22:05.760' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (43, 4, 7, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.760' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (44, 4, 8, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.760' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (45, 4, 9, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.760' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (46, 4, 10, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.760' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (47, 4, 11, 1, 1, NULL, CAST(N'2026-09-01T17:22:05.760' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (48, 4, 12, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.760' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (49, 5, 1, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.770' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (50, 5, 2, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.770' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (51, 5, 3, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.770' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (52, 5, 4, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.770' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (53, 5, 5, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.770' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (54, 5, 6, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.770' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (55, 5, 7, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.770' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (56, 5, 8, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.770' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (57, 5, 9, 3, 1, NULL, CAST(N'2026-09-01T17:22:05.770' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (58, 5, 10, 3, 1, NULL, CAST(N'2026-09-01T17:22:05.770' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (59, 5, 11, 1, 1, NULL, CAST(N'2026-09-01T17:22:05.770' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (60, 5, 12, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.770' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (61, 6, 1, 1, 1, NULL, CAST(N'2026-09-01T17:22:05.780' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (62, 6, 2, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.780' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (63, 6, 3, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.780' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (64, 6, 4, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.780' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (65, 6, 5, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.780' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (66, 6, 6, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.780' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (67, 6, 7, 1, 1, NULL, CAST(N'2026-09-01T17:22:05.780' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (68, 6, 8, 1, 1, NULL, CAST(N'2026-09-01T17:22:05.780' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (69, 6, 9, 1, 1, NULL, CAST(N'2026-09-01T17:22:05.780' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (70, 6, 10, 1, 1, NULL, CAST(N'2026-09-01T17:22:05.780' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (71, 6, 11, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.780' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (72, 6, 12, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.780' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (73, 7, 1, 1, 1, NULL, CAST(N'2026-09-01T17:22:05.790' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (74, 7, 2, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.790' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (75, 7, 3, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.790' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (76, 7, 4, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.790' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (77, 7, 5, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.790' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (78, 7, 6, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.790' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (79, 7, 7, 1, 1, NULL, CAST(N'2026-09-01T17:22:05.790' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (80, 7, 8, 1, 1, NULL, CAST(N'2026-09-01T17:22:05.790' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (81, 7, 9, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.790' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (82, 7, 10, 1, 1, NULL, CAST(N'2026-09-01T17:22:05.790' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (83, 7, 11, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.790' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[RoleMenus] ([RoleMenuId], [RoleId], [MenuId], [PermissionLevel], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (84, 7, 12, 0, 1, NULL, CAST(N'2026-09-01T17:22:05.790' AS DateTime), NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[RoleMenus] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [RoleDescription]) VALUES (1, N'مدیر سیستم', N'دسترسی کامل به تمام بخش‌های سامانه')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [RoleDescription]) VALUES (2, N'مدیر باشگاه', N'مدیریت کامل باشگاه ورزشی، اعضا، سانس‌ها و رزروها')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [RoleDescription]) VALUES (3, N'پذیرش باشگاه', N'مدیریت پذیرش، مشاهده اعضا و ثبت رزرو')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [RoleDescription]) VALUES (4, N'مدیر ساختمان', N'مدیریت واحدها، مالکین و ساکنین برج')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [RoleDescription]) VALUES (5, N'حسابدار', N'مدیریت شارژ، پرداخت‌ها و گزارش‌های مالی')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [RoleDescription]) VALUES (6, N'ساکن', N'دسترسی عمومی ساکنین به خدمات ساختمان و باشگاه')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [RoleDescription]) VALUES (7, N'عضو خارجی باشگاه', N'کاربر خارج از برج که عضو باشگاه ورزشی است')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Units] ON 
GO
INSERT [dbo].[Units] ([UnitId], [BuildingId], [UnitNumber], [FloorNumber], [Area], [Bedrooms], [UnitDescription], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (1, 1, N'101', 1, CAST(145.50 AS Decimal(10, 2)), 3, N'واحد مسکونی طبقه اول - سه خوابه', 1, NULL, CAST(N'2026-09-01T17:22:05.320' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Units] ([UnitId], [BuildingId], [UnitNumber], [FloorNumber], [Area], [Bedrooms], [UnitDescription], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (2, 1, N'102', 1, CAST(120.00 AS Decimal(10, 2)), 2, N'واحد مسکونی طبقه اول - دو خوابه', 1, NULL, CAST(N'2026-09-01T17:22:05.320' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Units] ([UnitId], [BuildingId], [UnitNumber], [FloorNumber], [Area], [Bedrooms], [UnitDescription], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (3, 1, N'201', 2, CAST(165.75 AS Decimal(10, 2)), 3, N'واحد مسکونی طبقه دوم - سه خوابه', 1, NULL, CAST(N'2026-09-01T17:22:05.320' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Units] ([UnitId], [BuildingId], [UnitNumber], [FloorNumber], [Area], [Bedrooms], [UnitDescription], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (4, 1, N'202', 2, CAST(135.00 AS Decimal(10, 2)), 3, N'واحد مسکونی طبقه دوم - سه خوابه', 1, NULL, CAST(N'2026-09-01T17:22:05.320' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Units] ([UnitId], [BuildingId], [UnitNumber], [FloorNumber], [Area], [Bedrooms], [UnitDescription], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (5, 1, N'301', 3, CAST(180.25 AS Decimal(10, 2)), 4, N'واحد مسکونی طبقه سوم - چهار خوابه', 1, NULL, CAST(N'2026-09-01T17:22:05.320' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Units] ([UnitId], [BuildingId], [UnitNumber], [FloorNumber], [Area], [Bedrooms], [UnitDescription], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (6, 1, N'302', 3, CAST(150.00 AS Decimal(10, 2)), 3, N'واحد مسکونی طبقه سوم - سه خوابه', 1, NULL, CAST(N'2026-09-01T17:22:05.320' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Units] ([UnitId], [BuildingId], [UnitNumber], [FloorNumber], [Area], [Bedrooms], [UnitDescription], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (7, 1, N'401', 4, CAST(210.00 AS Decimal(10, 2)), 4, N'واحد ویژه طبقه چهارم - چهار خوابه', 1, NULL, CAST(N'2026-09-01T17:22:05.320' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Units] ([UnitId], [BuildingId], [UnitNumber], [FloorNumber], [Area], [Bedrooms], [UnitDescription], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (8, 1, N'402', 4, CAST(175.00 AS Decimal(10, 2)), 3, N'واحد مسکونی طبقه چهارم - سه خوابه', 1, NULL, CAST(N'2026-09-01T17:22:05.320' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Units] ([UnitId], [BuildingId], [UnitNumber], [FloorNumber], [Area], [Bedrooms], [UnitDescription], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (9, 1, N'501', 5, CAST(250.00 AS Decimal(10, 2)), 4, N'پنت هاوس طبقه پنجم', 1, NULL, CAST(N'2026-09-01T17:22:05.320' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Units] ([UnitId], [BuildingId], [UnitNumber], [FloorNumber], [Area], [Bedrooms], [UnitDescription], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (10, 1, N'502', 5, CAST(220.00 AS Decimal(10, 2)), 4, N'پنت هاوس طبقه پنجم', 1, NULL, CAST(N'2026-09-01T17:22:05.320' AS DateTime), NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Units] OFF
GO
SET IDENTITY_INSERT [dbo].[UserProfiles] ON 
GO
INSERT [dbo].[UserProfiles] ([UserProfileId], [UserId], [FatherName], [BirthPlace], [LandlinePhone], [UserPostalCode], [UserAddress], [EmergencyContactName], [EmergencyContactMobile], [EmergencyContactRelation], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (1, 1, N'حسین', N'تهران', N'02122000001', N'1111111111', N'تهران، خیابان ولیعصر', N'محمد محمدی', N'09121111111', N'برادر', N'کاربر مدیر سیستم', CAST(N'2026-09-01T17:22:05.510' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserProfiles] ([UserProfileId], [UserId], [FatherName], [BirthPlace], [LandlinePhone], [UserPostalCode], [UserAddress], [EmergencyContactName], [EmergencyContactMobile], [EmergencyContactRelation], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (2, 2, N'اکبر', N'تهران', N'02122000002', N'1111111112', N'تهران، خیابان پاسداران', N'علی احمدی', N'09121111112', N'برادر', N'مدیر باشگاه', CAST(N'2026-09-01T17:22:05.510' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserProfiles] ([UserProfileId], [UserId], [FatherName], [BirthPlace], [LandlinePhone], [UserPostalCode], [UserAddress], [EmergencyContactName], [EmergencyContactMobile], [EmergencyContactRelation], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (3, 3, N'کاظم', N'تهران', N'02122000003', N'1111111113', N'تهران، خیابان شریعتی', N'حسن کریمی', N'09121111113', N'برادر', N'مدیر ساختمان', CAST(N'2026-09-01T17:22:05.510' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserProfiles] ([UserProfileId], [UserId], [FatherName], [BirthPlace], [LandlinePhone], [UserPostalCode], [UserAddress], [EmergencyContactName], [EmergencyContactMobile], [EmergencyContactRelation], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (4, 4, N'محمود', N'تهران', N'02122000004', N'1111111114', N'تهران، خیابان مطهری', N'مریم محمدی', N'09121111114', N'خواهر', N'حسابدار ساختمان', CAST(N'2026-09-01T17:22:05.510' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserProfiles] ([UserProfileId], [UserId], [FatherName], [BirthPlace], [LandlinePhone], [UserPostalCode], [UserAddress], [EmergencyContactName], [EmergencyContactMobile], [EmergencyContactRelation], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (5, 5, N'رضا', N'تهران', N'02122000005', N'1111111115', N'تهران، خیابان انقلاب', N'سارا حسینی', N'09121111115', N'خواهر', N'پذیرش باشگاه', CAST(N'2026-09-01T17:22:05.510' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserProfiles] ([UserProfileId], [UserId], [FatherName], [BirthPlace], [LandlinePhone], [UserPostalCode], [UserAddress], [EmergencyContactName], [EmergencyContactMobile], [EmergencyContactRelation], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (6, 6, N'حسن', N'تهران', N'02122000006', N'1111111116', N'تهران، برج بوستان، واحد ۱۰۱', N'مریم احمدی', N'09120000007', N'همسر', N'مالک واحد ۱۰۱', CAST(N'2026-09-01T17:22:05.510' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserProfiles] ([UserProfileId], [UserId], [FatherName], [BirthPlace], [LandlinePhone], [UserPostalCode], [UserAddress], [EmergencyContactName], [EmergencyContactMobile], [EmergencyContactRelation], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (7, 7, N'علی', N'تهران', N'02122000007', N'1111111116', N'تهران، برج بوستان، واحد ۱۰۱', N'علی محمدی', N'09120000006', N'همسر', N'ساکن واحد ۱۰۱', CAST(N'2026-09-01T17:22:05.510' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserProfiles] ([UserProfileId], [UserId], [FatherName], [BirthPlace], [LandlinePhone], [UserPostalCode], [UserAddress], [EmergencyContactName], [EmergencyContactMobile], [EmergencyContactRelation], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (8, 8, N'محمود', N'تهران', N'02122000008', N'1111111118', N'تهران، برج بوستان، واحد ۲۰۱', N'فاطمه رضایی', N'09120000009', N'همسر', N'مالک واحد ۲۰۱', CAST(N'2026-09-01T17:22:05.510' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserProfiles] ([UserProfileId], [UserId], [FatherName], [BirthPlace], [LandlinePhone], [UserPostalCode], [UserAddress], [EmergencyContactName], [EmergencyContactMobile], [EmergencyContactRelation], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (9, 9, N'حسن', N'تهران', N'02122000008', N'1111111118', N'تهران، برج بوستان، واحد ۲۰۱', N'حسن رضایی', N'09120000008', N'همسر', N'ساکن واحد ۲۰۱', CAST(N'2026-09-01T17:22:05.510' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserProfiles] ([UserProfileId], [UserId], [FatherName], [BirthPlace], [LandlinePhone], [UserPostalCode], [UserAddress], [EmergencyContactName], [EmergencyContactMobile], [EmergencyContactRelation], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (10, 10, N'احمد', N'تهران', N'02122000010', N'1111111120', N'تهران، خیابان آزادی', N'علی سلیمانی', N'09121111120', N'برادر', N'عضو خارجی باشگاه', CAST(N'2026-09-01T17:22:05.510' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserProfiles] ([UserProfileId], [UserId], [FatherName], [BirthPlace], [LandlinePhone], [UserPostalCode], [UserAddress], [EmergencyContactName], [EmergencyContactMobile], [EmergencyContactRelation], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (11, 11, N'حسین', N'تهران', NULL, NULL, NULL, N'علی محمدی', N'09120000006', N'دوست', N'مهمان واحد ۱۰۱', CAST(N'2026-09-01T17:22:05.510' AS DateTime), NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[UserProfiles] OFF
GO
SET IDENTITY_INSERT [dbo].[UserResidencies] ON 
GO
INSERT [dbo].[UserResidencies] ([UserResidencyId], [UserId], [UnitId], [RelationshipType], [StartDate], [EndDate], [IsActive], [IsDeleted], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (1, 6, 1, 1, CAST(N'2020-01-01T00:00:00.000' AS DateTime), NULL, 1, NULL, N'مالک اصلی واحد ۱۰۱', CAST(N'2026-09-01T17:22:05.550' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserResidencies] ([UserResidencyId], [UserId], [UnitId], [RelationshipType], [StartDate], [EndDate], [IsActive], [IsDeleted], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (2, 7, 1, 2, CAST(N'2020-01-01T00:00:00.000' AS DateTime), NULL, 1, NULL, N'ساکن واحد ۱۰۱', CAST(N'2026-09-01T17:22:05.560' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserResidencies] ([UserResidencyId], [UserId], [UnitId], [RelationshipType], [StartDate], [EndDate], [IsActive], [IsDeleted], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (3, 8, 3, 1, CAST(N'2019-05-01T00:00:00.000' AS DateTime), NULL, 1, NULL, N'مالک اصلی واحد ۲۰۱', CAST(N'2026-09-01T17:22:05.567' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserResidencies] ([UserResidencyId], [UserId], [UnitId], [RelationshipType], [StartDate], [EndDate], [IsActive], [IsDeleted], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (4, 9, 3, 2, CAST(N'2019-05-01T00:00:00.000' AS DateTime), NULL, 1, NULL, N'ساکن واحد ۲۰۱', CAST(N'2026-09-01T17:22:05.580' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[UserResidencies] ([UserResidencyId], [UserId], [UnitId], [RelationshipType], [StartDate], [EndDate], [IsActive], [IsDeleted], [Notes], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (5, 11, 1, 4, CAST(N'2026-09-01T00:00:00.000' AS DateTime), CAST(N'2026-09-05T00:00:00.000' AS DateTime), 1, NULL, N'مهمان موقت واحد ۱۰۱', CAST(N'2026-09-01T17:22:05.590' AS DateTime), NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[UserResidencies] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRoles] ON 
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [AssignedAt], [ExpiresAt], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater], [Notes]) VALUES (1, 1, 1, CAST(N'2026-09-01T17:22:05.673' AS DateTime), NULL, 1, NULL, CAST(N'2026-09-01T17:22:05.673' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [AssignedAt], [ExpiresAt], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater], [Notes]) VALUES (2, 2, 2, CAST(N'2026-09-01T17:22:05.673' AS DateTime), NULL, 1, NULL, CAST(N'2026-09-01T17:22:05.673' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [AssignedAt], [ExpiresAt], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater], [Notes]) VALUES (3, 3, 4, CAST(N'2026-09-01T17:22:05.673' AS DateTime), NULL, 1, NULL, CAST(N'2026-09-01T17:22:05.673' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [AssignedAt], [ExpiresAt], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater], [Notes]) VALUES (4, 4, 5, CAST(N'2026-09-01T17:22:05.677' AS DateTime), NULL, 1, NULL, CAST(N'2026-09-01T17:22:05.677' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [AssignedAt], [ExpiresAt], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater], [Notes]) VALUES (5, 5, 3, CAST(N'2026-09-01T17:22:05.677' AS DateTime), NULL, 1, NULL, CAST(N'2026-09-01T17:22:05.677' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [AssignedAt], [ExpiresAt], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater], [Notes]) VALUES (6, 6, 6, CAST(N'2026-09-01T17:22:05.677' AS DateTime), NULL, 1, NULL, CAST(N'2026-09-01T17:22:05.677' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [AssignedAt], [ExpiresAt], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater], [Notes]) VALUES (7, 7, 6, CAST(N'2026-09-01T17:22:05.677' AS DateTime), NULL, 1, NULL, CAST(N'2026-09-01T17:22:05.677' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [AssignedAt], [ExpiresAt], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater], [Notes]) VALUES (8, 8, 6, CAST(N'2026-09-01T17:22:05.680' AS DateTime), NULL, 1, NULL, CAST(N'2026-09-01T17:22:05.680' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [AssignedAt], [ExpiresAt], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater], [Notes]) VALUES (9, 9, 6, CAST(N'2026-09-01T17:22:05.680' AS DateTime), NULL, 1, NULL, CAST(N'2026-09-01T17:22:05.680' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [AssignedAt], [ExpiresAt], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater], [Notes]) VALUES (10, 10, 7, CAST(N'2026-09-01T17:22:05.680' AS DateTime), NULL, 1, NULL, CAST(N'2026-09-01T17:22:05.680' AS DateTime), NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Mobile], [FirstName], [LastName], [NationalId], [Gender], [BirthDate], [AvatarUrl], [PhoneVerified], [LastLoginAt], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (1, N'admin', N'1234', N'admin@boosatan.ir', N'09120000001', N'مدیر', N'سیستم', N'0012345678', 1, CAST(N'1985-01-15T00:00:00.000' AS DateTime), NULL, 1, CAST(N'2026-09-10T14:10:42.107' AS DateTime), 1, NULL, CAST(N'2026-09-01T17:22:05.450' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Mobile], [FirstName], [LastName], [NationalId], [Gender], [BirthDate], [AvatarUrl], [PhoneVerified], [LastLoginAt], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (2, N'club.manager', N'1234', N'club.manager@boosatan.ir', N'09120000002', N'رضا', N'احمدی', N'0012345679', 1, CAST(N'1988-03-20T00:00:00.000' AS DateTime), NULL, 1, NULL, 1, NULL, CAST(N'2026-09-01T17:22:05.453' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Mobile], [FirstName], [LastName], [NationalId], [Gender], [BirthDate], [AvatarUrl], [PhoneVerified], [LastLoginAt], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (3, N'building.manager', N'1234', N'building.manager@boosatan.ir', N'09120000003', N'مهدی', N'کریمی', N'0012345680', 1, CAST(N'1982-07-10T00:00:00.000' AS DateTime), NULL, 1, NULL, 1, NULL, CAST(N'2026-09-01T17:22:05.457' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Mobile], [FirstName], [LastName], [NationalId], [Gender], [BirthDate], [AvatarUrl], [PhoneVerified], [LastLoginAt], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (4, N'accountant', N'1234', N'accountant@boosatan.ir', N'09120000004', N'سارا', N'محمدی', N'0012345681', 2, CAST(N'1990-11-05T00:00:00.000' AS DateTime), NULL, 1, NULL, 1, NULL, CAST(N'2026-09-01T17:22:05.460' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Mobile], [FirstName], [LastName], [NationalId], [Gender], [BirthDate], [AvatarUrl], [PhoneVerified], [LastLoginAt], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (5, N'reception', N'1234', N'reception@boosatan.ir', N'09120000005', N'نگار', N'حسینی', N'0012345682', 2, CAST(N'1994-04-12T00:00:00.000' AS DateTime), NULL, 1, NULL, 1, NULL, CAST(N'2026-09-01T17:22:05.460' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Mobile], [FirstName], [LastName], [NationalId], [Gender], [BirthDate], [AvatarUrl], [PhoneVerified], [LastLoginAt], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (6, N'ali.mohammadi', N'1234', N'ali.mohammadi@example.com', N'09120000006', N'علی', N'محمدی', N'0012345683', 1, CAST(N'1987-06-18T00:00:00.000' AS DateTime), NULL, 1, NULL, 1, NULL, CAST(N'2026-09-01T17:22:05.460' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Mobile], [FirstName], [LastName], [NationalId], [Gender], [BirthDate], [AvatarUrl], [PhoneVerified], [LastLoginAt], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (7, N'maryam.ahmadi', N'1234', N'maryam.ahmadi@example.com', N'09120000007', N'مریم', N'احمدی', N'0012345684', 2, CAST(N'1991-02-25T00:00:00.000' AS DateTime), NULL, 1, NULL, 1, NULL, CAST(N'2026-09-01T17:22:05.463' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Mobile], [FirstName], [LastName], [NationalId], [Gender], [BirthDate], [AvatarUrl], [PhoneVerified], [LastLoginAt], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (8, N'hassan.rezaei', N'1234', N'hassan.rezaei@example.com', N'09120000008', N'حسن', N'رضایی', N'0012345685', 1, CAST(N'1980-09-03T00:00:00.000' AS DateTime), NULL, 1, NULL, 1, NULL, CAST(N'2026-09-01T17:22:05.463' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Mobile], [FirstName], [LastName], [NationalId], [Gender], [BirthDate], [AvatarUrl], [PhoneVerified], [LastLoginAt], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (9, N'fatemeh.rezaei', N'1234', N'fatemeh.rezaei@example.com', N'09120000009', N'فاطمه', N'رضایی', N'0012345686', 2, CAST(N'1985-12-14T00:00:00.000' AS DateTime), NULL, 1, NULL, 1, NULL, CAST(N'2026-09-01T17:22:05.467' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Mobile], [FirstName], [LastName], [NationalId], [Gender], [BirthDate], [AvatarUrl], [PhoneVerified], [LastLoginAt], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (10, N'mohammad.soleimani', N'1234', N'mohammad.soleimani@example.com', N'09120000010', N'محمد', N'سلیمانی', N'0012345687', 1, CAST(N'1993-08-21T00:00:00.000' AS DateTime), NULL, 1, NULL, 1, NULL, CAST(N'2026-09-01T17:22:05.467' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Users] ([UserId], [Username], [PasswordHash], [Email], [Mobile], [FirstName], [LastName], [NationalId], [Gender], [BirthDate], [AvatarUrl], [PhoneVerified], [LastLoginAt], [IsActive], [IsDeleted], [CreatedAt], [UserCreater], [UpdatedAt], [UserUpdater]) VALUES (11, N'guest.test', N'1234', N'guest@example.com', N'09120000011', N'رضا', N'کاظمی', N'0012345688', 1, CAST(N'1995-10-10T00:00:00.000' AS DateTime), NULL, 0, NULL, 1, NULL, CAST(N'2026-09-01T17:22:05.470' AS DateTime), NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [UQ_RoleMenus_Role_Menu]    Script Date: 9/11/2026 7:47:02 PM ******/
ALTER TABLE [dbo].[RoleMenus] ADD  CONSTRAINT [UQ_RoleMenus_Role_Menu] UNIQUE NONCLUSTERED 
(
	[RoleId] ASC,
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_UserOtpRateLimits_Mobile]    Script Date: 9/11/2026 7:47:02 PM ******/
ALTER TABLE [dbo].[UserOtpRateLimits] ADD  CONSTRAINT [UQ_UserOtpRateLimits_Mobile] UNIQUE NONCLUSTERED 
(
	[Mobile] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_UserProfiles_UserId]    Script Date: 9/11/2026 7:47:02 PM ******/
ALTER TABLE [dbo].[UserProfiles] ADD  CONSTRAINT [UQ_UserProfiles_UserId] UNIQUE NONCLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_UserRoles_User_Role]    Script Date: 9/11/2026 7:47:02 PM ******/
ALTER TABLE [dbo].[UserRoles] ADD  CONSTRAINT [UQ_UserRoles_User_Role] UNIQUE NONCLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Users_Email]    Script Date: 9/11/2026 7:47:02 PM ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ_Users_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Users_NationalId]    Script Date: 9/11/2026 7:47:02 PM ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ_Users_NationalId] UNIQUE NONCLUSTERED 
(
	[NationalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Users_Username]    Script Date: 9/11/2026 7:47:02 PM ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ_Users_Username] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Buildings] ADD  CONSTRAINT [DF_Buildings_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Buildings] ADD  CONSTRAINT [DF_Buildings_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[EmployeeAssignments] ADD  CONSTRAINT [DF_EmployeeAssignments_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[EmployeeAssignments] ADD  CONSTRAINT [DF_EmployeeAssignments_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[EmployeeTypes] ADD  CONSTRAINT [DF_EmployeeTypes_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[EmployeeTypes] ADD  CONSTRAINT [DF_EmployeeTypes_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Menus] ADD  CONSTRAINT [DF_Menus_SortOrder]  DEFAULT ((0)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[Menus] ADD  CONSTRAINT [DF_Menus_IsVisible]  DEFAULT ((1)) FOR [IsVisible]
GO
ALTER TABLE [dbo].[Menus] ADD  CONSTRAINT [DF_Menus_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Menus] ADD  CONSTRAINT [DF_Menus_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Organizations] ADD  CONSTRAINT [DF_Orgs_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Organizations] ADD  CONSTRAINT [DF_Orgs_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[RoleMenus] ADD  CONSTRAINT [DF_RoleMenus_PermissionLevel]  DEFAULT ((0)) FOR [PermissionLevel]
GO
ALTER TABLE [dbo].[RoleMenus] ADD  CONSTRAINT [DF_RoleMenus_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[RoleMenus] ADD  CONSTRAINT [DF_RoleMenus_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Spaces] ADD  CONSTRAINT [DF_Spaces_IsReservable]  DEFAULT ((0)) FOR [IsReservable]
GO
ALTER TABLE [dbo].[Spaces] ADD  CONSTRAINT [DF_Spaces_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Spaces] ADD  CONSTRAINT [DF_Spaces_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Units] ADD  CONSTRAINT [DF_Units_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Units] ADD  CONSTRAINT [DF_Units_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[UserOtpRateLimits] ADD  CONSTRAINT [DF_UserOtpRateLimits_RequestCount]  DEFAULT ((0)) FOR [RequestCount]
GO
ALTER TABLE [dbo].[UserOtpRateLimits] ADD  CONSTRAINT [DF_UserOtpRateLimits_DailyCount]  DEFAULT ((0)) FOR [DailyCount]
GO
ALTER TABLE [dbo].[UserOtpRequests] ADD  CONSTRAINT [DF_UserOtpRequests_CreatedAt]  DEFAULT (sysdatetime()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[UserOtpRequests] ADD  CONSTRAINT [DF_UserOtpRequests_AttemptCount]  DEFAULT ((0)) FOR [AttemptCount]
GO
ALTER TABLE [dbo].[UserOtpRequests] ADD  CONSTRAINT [DF_UserOtpRequests_MaxAttempts]  DEFAULT ((5)) FOR [MaxAttempts]
GO
ALTER TABLE [dbo].[UserOtpRequests] ADD  CONSTRAINT [DF_UserOtpRequests_IsUsed]  DEFAULT ((0)) FOR [IsUsed]
GO
ALTER TABLE [dbo].[UserOtpRequests] ADD  CONSTRAINT [DF_UserOtpRequests_IsBlocked]  DEFAULT ((0)) FOR [IsBlocked]
GO
ALTER TABLE [dbo].[UserProfiles] ADD  CONSTRAINT [DF_UserProfiles_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[UserResidencies] ADD  CONSTRAINT [DF_UserResidencies_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[UserResidencies] ADD  CONSTRAINT [DF_UserResidencies_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[UserRoles] ADD  CONSTRAINT [DF_UserRoles_AssignedAt]  DEFAULT (getdate()) FOR [AssignedAt]
GO
ALTER TABLE [dbo].[UserRoles] ADD  CONSTRAINT [DF_UserRoles_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[UserRoles] ADD  CONSTRAINT [DF_UserRoles_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_PhoneVerified]  DEFAULT ((0)) FOR [PhoneVerified]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Buildings]  WITH CHECK ADD  CONSTRAINT [FK_Buildings_Orgs] FOREIGN KEY([OrgId])
REFERENCES [dbo].[Organizations] ([OrgId])
GO
ALTER TABLE [dbo].[Buildings] CHECK CONSTRAINT [FK_Buildings_Orgs]
GO
ALTER TABLE [dbo].[EmployeeAssignments]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeAssignments_Buildings] FOREIGN KEY([BuildingId])
REFERENCES [dbo].[Buildings] ([BuildingId])
GO
ALTER TABLE [dbo].[EmployeeAssignments] CHECK CONSTRAINT [FK_EmployeeAssignments_Buildings]
GO
ALTER TABLE [dbo].[EmployeeAssignments]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeAssignments_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[EmployeeAssignments] CHECK CONSTRAINT [FK_EmployeeAssignments_Employees]
GO
ALTER TABLE [dbo].[EmployeeAssignments]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeAssignments_Org] FOREIGN KEY([OrgId])
REFERENCES [dbo].[Organizations] ([OrgId])
GO
ALTER TABLE [dbo].[EmployeeAssignments] CHECK CONSTRAINT [FK_EmployeeAssignments_Org]
GO
ALTER TABLE [dbo].[EmployeeAssignments]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeAssignments_Spaces] FOREIGN KEY([SpaceId])
REFERENCES [dbo].[Spaces] ([SpaceId])
GO
ALTER TABLE [dbo].[EmployeeAssignments] CHECK CONSTRAINT [FK_EmployeeAssignments_Spaces]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Org] FOREIGN KEY([OrgId])
REFERENCES [dbo].[Organizations] ([OrgId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Org]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Types] FOREIGN KEY([EmployeeTypeId])
REFERENCES [dbo].[EmployeeTypes] ([EmployeeTypeId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Types]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Users]
GO
ALTER TABLE [dbo].[Geo]  WITH CHECK ADD  CONSTRAINT [FK_Geo_Geo] FOREIGN KEY([ParantId])
REFERENCES [dbo].[Geo] ([GeoId])
GO
ALTER TABLE [dbo].[Geo] CHECK CONSTRAINT [FK_Geo_Geo]
GO
ALTER TABLE [dbo].[Menus]  WITH CHECK ADD  CONSTRAINT [FK_Menus_Parent] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Menus] ([MenuId])
GO
ALTER TABLE [dbo].[Menus] CHECK CONSTRAINT [FK_Menus_Parent]
GO
ALTER TABLE [dbo].[Organizations]  WITH CHECK ADD  CONSTRAINT [FK_Organizations_Geo] FOREIGN KEY([GeoId])
REFERENCES [dbo].[Geo] ([GeoId])
GO
ALTER TABLE [dbo].[Organizations] CHECK CONSTRAINT [FK_Organizations_Geo]
GO
ALTER TABLE [dbo].[RoleMenus]  WITH CHECK ADD  CONSTRAINT [FK_RoleMenus_Menus] FOREIGN KEY([MenuId])
REFERENCES [dbo].[Menus] ([MenuId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleMenus] CHECK CONSTRAINT [FK_RoleMenus_Menus]
GO
ALTER TABLE [dbo].[RoleMenus]  WITH CHECK ADD  CONSTRAINT [FK_RoleMenus_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleMenus] CHECK CONSTRAINT [FK_RoleMenus_Roles]
GO
ALTER TABLE [dbo].[Spaces]  WITH CHECK ADD  CONSTRAINT [FK_Spaces_Buildings] FOREIGN KEY([BuildingId])
REFERENCES [dbo].[Buildings] ([BuildingId])
GO
ALTER TABLE [dbo].[Spaces] CHECK CONSTRAINT [FK_Spaces_Buildings]
GO
ALTER TABLE [dbo].[Spaces]  WITH CHECK ADD  CONSTRAINT [FK_Spaces_Orgs] FOREIGN KEY([OrgId])
REFERENCES [dbo].[Organizations] ([OrgId])
GO
ALTER TABLE [dbo].[Spaces] CHECK CONSTRAINT [FK_Spaces_Orgs]
GO
ALTER TABLE [dbo].[Spaces]  WITH CHECK ADD  CONSTRAINT [FK_Spaces_Parent] FOREIGN KEY([ParentSpaceId])
REFERENCES [dbo].[Spaces] ([SpaceId])
GO
ALTER TABLE [dbo].[Spaces] CHECK CONSTRAINT [FK_Spaces_Parent]
GO
ALTER TABLE [dbo].[Units]  WITH CHECK ADD  CONSTRAINT [FK_Units_Buildings] FOREIGN KEY([BuildingId])
REFERENCES [dbo].[Buildings] ([BuildingId])
GO
ALTER TABLE [dbo].[Units] CHECK CONSTRAINT [FK_Units_Buildings]
GO
ALTER TABLE [dbo].[UserOtpRequests]  WITH CHECK ADD  CONSTRAINT [FK_UserOtpRequests_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[UserOtpRequests] CHECK CONSTRAINT [FK_UserOtpRequests_Users]
GO
ALTER TABLE [dbo].[UserProfiles]  WITH CHECK ADD  CONSTRAINT [FK_UserProfiles_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserProfiles] CHECK CONSTRAINT [FK_UserProfiles_Users]
GO
ALTER TABLE [dbo].[UserResidencies]  WITH CHECK ADD  CONSTRAINT [FK_UserResidencies_Units] FOREIGN KEY([UnitId])
REFERENCES [dbo].[Units] ([UnitId])
GO
ALTER TABLE [dbo].[UserResidencies] CHECK CONSTRAINT [FK_UserResidencies_Units]
GO
ALTER TABLE [dbo].[UserResidencies]  WITH CHECK ADD  CONSTRAINT [FK_UserResidencies_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserResidencies] CHECK CONSTRAINT [FK_UserResidencies_Users]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users]
GO
/****** Object:  StoredProcedure [dbo].[BuildingsAdd]    Script Date: 9/11/2026 7:47:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* =========================================================
   BuildingsAdd
   ========================================================= */
CREATE   PROCEDURE [dbo].[BuildingsAdd]
(
    @BuildingName        NVARCHAR(150),
    @BuildingAddress     NVARCHAR(500) = NULL,
    @BuildingDescription NVARCHAR(1000) = NULL,
    @IsActive            BIT = 1,
    @OrgId               BIGINT = NULL,
    @UserCreater         INT = NULL,

    @ResultCode          INT OUTPUT,
    @ResultMessage       NVARCHAR(500) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    SET @ResultCode = 500;
    SET @ResultMessage = N'خطای داخلی در ثبت ساختمان.';

    BEGIN TRY

        ---------------------------------------------------------
        -- Validation
        ---------------------------------------------------------
        IF NULLIF(LTRIM(RTRIM(@BuildingName)), N'') IS NULL
        BEGIN
            SET @ResultCode = 400;
            SET @ResultMessage = N'نام ساختمان الزامی است.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- بررسی Organization
        ---------------------------------------------------------
        IF @OrgId IS NOT NULL
           AND NOT EXISTS
           (
               SELECT 1
               FROM dbo.Organizations
               WHERE OrgId = @OrgId
                 AND ISNULL(IsDeleted, 0) = 0
           )
        BEGIN
            SET @ResultCode = 404;
            SET @ResultMessage = N'سازمان انتخاب شده وجود ندارد یا حذف شده است.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- بررسی نام تکراری ساختمان
        ---------------------------------------------------------
        IF EXISTS
        (
            SELECT 1
            FROM dbo.Buildings
            WHERE LTRIM(RTRIM(BuildingName)) = LTRIM(RTRIM(@BuildingName))
              AND ISNULL(IsDeleted, 0) = 0
        )
        BEGIN
            SET @ResultCode = 409;
            SET @ResultMessage = N'ساختمانی با این نام قبلاً ثبت شده است.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- Insert
        ---------------------------------------------------------
        INSERT INTO dbo.Buildings
        (
            BuildingName,
            BuildingAddress,
            BuildingDescription,
            IsActive,
            IsDeleted,
            CreatedAt,
            UserCreater,
            OrgId
        )
        VALUES
        (
            LTRIM(RTRIM(@BuildingName)),
            @BuildingAddress,
            @BuildingDescription,
            ISNULL(@IsActive, 1),
            0,
            GETDATE(),
            @UserCreater,
            @OrgId
        );

        SET @ResultCode = 200;
        SET @ResultMessage = N'ساختمان با موفقیت ثبت شد.';

        ---------------------------------------------------------
        -- رکورد ایجاد شده
        ---------------------------------------------------------
        SELECT
            B.*
        FROM dbo.Buildings AS B
        WHERE B.BuildingId = SCOPE_IDENTITY();

    END TRY
    BEGIN CATCH

        SET @ResultCode = ERROR_NUMBER();
        SET @ResultMessage = ERROR_MESSAGE();

    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[BuildingsDel]    Script Date: 9/11/2026 7:47:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* =========================================================
   BuildingsDel
   Soft Delete
   ========================================================= */
CREATE   PROCEDURE [dbo].[BuildingsDel]
(
    @BuildingId  BIGINT,
    @UserUpdater INT = NULL,

    @ResultCode  INT OUTPUT,
    @ResultMessage NVARCHAR(500) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    SET @ResultCode = 500;
    SET @ResultMessage = N'خطای داخلی در حذف ساختمان.';

    BEGIN TRY

        IF @BuildingId IS NULL OR @BuildingId <= 0
        BEGIN
            SET @ResultCode = 400;
            SET @ResultMessage = N'کد ساختمان معتبر نیست.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- بررسی وجود ساختمان
        ---------------------------------------------------------
        IF NOT EXISTS
        (
            SELECT 1
            FROM dbo.Buildings
            WHERE BuildingId = @BuildingId
              AND ISNULL(IsDeleted, 0) = 0
        )
        BEGIN
            SET @ResultCode = 404;
            SET @ResultMessage = N'ساختمان مورد نظر یافت نشد.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- بررسی وابستگی Units
        ---------------------------------------------------------
        IF EXISTS
        (
            SELECT 1
            FROM dbo.Units
            WHERE BuildingId = @BuildingId
              AND ISNULL(IsDeleted, 0) = 0
        )
        BEGIN
            SET @ResultCode = 409;
            SET @ResultMessage =
                N'امکان حذف ساختمان وجود ندارد؛ برای این ساختمان واحد ثبت شده است.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- Soft Delete
        ---------------------------------------------------------
        UPDATE dbo.Buildings
        SET
            IsDeleted = 1,
            IsActive = 0,
            UpdatedAt = GETDATE(),
            UserUpdater = @UserUpdater
        WHERE BuildingId = @BuildingId;

        SET @ResultCode = 200;
        SET @ResultMessage = N'ساختمان با موفقیت حذف شد.';

    END TRY
    BEGIN CATCH

        SET @ResultCode = ERROR_NUMBER();
        SET @ResultMessage = ERROR_MESSAGE();

    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[BuildingsEdit]    Script Date: 9/11/2026 7:47:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* =========================================================
   BuildingsEdit
   ========================================================= */
CREATE   PROCEDURE [dbo].[BuildingsEdit]
(
    @BuildingId          BIGINT,
    @BuildingName        NVARCHAR(150),
    @BuildingAddress     NVARCHAR(500) = NULL,
    @BuildingDescription NVARCHAR(1000) = NULL,
    @IsActive            BIT = 1,
    @OrgId               BIGINT = NULL,
    @UserUpdater         INT = NULL,

    @ResultCode          INT OUTPUT,
    @ResultMessage       NVARCHAR(500) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    SET @ResultCode = 500;
    SET @ResultMessage = N'خطای داخلی در ویرایش ساختمان.';

    BEGIN TRY

        ---------------------------------------------------------
        -- Validation
        ---------------------------------------------------------
        IF @BuildingId IS NULL OR @BuildingId <= 0
        BEGIN
            SET @ResultCode = 400;
            SET @ResultMessage = N'کد ساختمان معتبر نیست.';
            RETURN;
        END;

        IF NULLIF(LTRIM(RTRIM(@BuildingName)), N'') IS NULL
        BEGIN
            SET @ResultCode = 400;
            SET @ResultMessage = N'نام ساختمان الزامی است.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- بررسی ساختمان
        ---------------------------------------------------------
        IF NOT EXISTS
        (
            SELECT 1
            FROM dbo.Buildings
            WHERE BuildingId = @BuildingId
              AND ISNULL(IsDeleted, 0) = 0
        )
        BEGIN
            SET @ResultCode = 404;
            SET @ResultMessage = N'ساختمان مورد نظر یافت نشد.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- بررسی Organization
        ---------------------------------------------------------
        IF @OrgId IS NOT NULL
           AND NOT EXISTS
           (
               SELECT 1
               FROM dbo.Organizations
               WHERE OrgId = @OrgId
                 AND ISNULL(IsDeleted, 0) = 0
           )
        BEGIN
            SET @ResultCode = 404;
            SET @ResultMessage = N'سازمان انتخاب شده وجود ندارد یا حذف شده است.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- بررسی نام تکراری
        ---------------------------------------------------------
        IF EXISTS
        (
            SELECT 1
            FROM dbo.Buildings
            WHERE LTRIM(RTRIM(BuildingName)) = LTRIM(RTRIM(@BuildingName))
              AND BuildingId <> @BuildingId
              AND ISNULL(IsDeleted, 0) = 0
        )
        BEGIN
            SET @ResultCode = 409;
            SET @ResultMessage = N'ساختمان دیگری با این نام قبلاً ثبت شده است.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- Update
        ---------------------------------------------------------
        UPDATE dbo.Buildings
        SET
            BuildingName        = LTRIM(RTRIM(@BuildingName)),
            BuildingAddress     = @BuildingAddress,
            BuildingDescription = @BuildingDescription,
            IsActive            = ISNULL(@IsActive, 1),
            OrgId               = @OrgId,
            UpdatedAt           = GETDATE(),
            UserUpdater         = @UserUpdater
        WHERE BuildingId = @BuildingId;

        SET @ResultCode = 200;
        SET @ResultMessage = N'ساختمان با موفقیت ویرایش شد.';

        SELECT
            B.*
        FROM dbo.Buildings AS B
        WHERE B.BuildingId = @BuildingId;

    END TRY
    BEGIN CATCH

        SET @ResultCode = ERROR_NUMBER();
        SET @ResultMessage = ERROR_MESSAGE();

    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[BuildingsGet]    Script Date: 9/11/2026 7:47:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* =========================================================
   BuildingsGet
   ========================================================= */
CREATE   PROCEDURE [dbo].[BuildingsGet]
(
    @BuildingId      BIGINT = NULL,
    @Search          NVARCHAR(150) = NULL,
    @PageNumber      INT = 1,
    @PageSize        INT = 50,
    @IncludeDeleted  BIT = 0,

    @ResultCode      INT OUTPUT,
    @ResultMessage   NVARCHAR(500) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    SET @ResultCode = 500;
    SET @ResultMessage = N'خطای داخلی در دریافت ساختمان‌ها.';

    BEGIN TRY

        SET @PageNumber = ISNULL(@PageNumber, 1);
        SET @PageSize = ISNULL(@PageSize, 50);
        SET @Search = NULLIF(LTRIM(RTRIM(@Search)), N'');

        IF @PageNumber < 1
            SET @PageNumber = 1;

        IF @PageSize < 1
            SET @PageSize = 50;

        IF @PageSize > 500
            SET @PageSize = 500;

        ---------------------------------------------------------
        -- دریافت یک رکورد
        ---------------------------------------------------------
        IF @BuildingId IS NOT NULL
        BEGIN

            IF NOT EXISTS
            (
                SELECT 1
                FROM dbo.Buildings
                WHERE BuildingId = @BuildingId
                  AND
                  (
                      @IncludeDeleted = 1
                      OR ISNULL(IsDeleted, 0) = 0
                  )
            )
            BEGIN
                SET @ResultCode = 404;
                SET @ResultMessage = N'ساختمان مورد نظر یافت نشد.';
                RETURN;
            END;

            SELECT
                B.*
            FROM dbo.Buildings AS B
            WHERE B.BuildingId = @BuildingId
              AND
              (
                  @IncludeDeleted = 1
                  OR ISNULL(B.IsDeleted, 0) = 0
              );

            SET @ResultCode = 200;
            SET @ResultMessage = N'اطلاعات ساختمان با موفقیت دریافت شد.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- دریافت لیست + Pagination
        ---------------------------------------------------------
        SELECT
            B.*
        FROM dbo.Buildings AS B
        WHERE
            (
                @IncludeDeleted = 1
                OR ISNULL(B.IsDeleted, 0) = 0
            )
            AND
            (
                @Search IS NULL
                OR B.BuildingName LIKE N'%' + ISNULL(@Search, N'') + N'%'
            )
        ORDER BY B.BuildingId DESC
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;

        SET @ResultCode = 200;
        SET @ResultMessage = N'لیست ساختمان‌ها با موفقیت دریافت شد.';

    END TRY
    BEGIN CATCH

        SET @ResultCode = ERROR_NUMBER();
        SET @ResultMessage = ERROR_MESSAGE();

    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[OrganizationsAdd]    Script Date: 9/11/2026 7:47:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* =========================================================
   OrganizationsAdd
   ========================================================= */
CREATE   PROCEDURE [dbo].[OrganizationsAdd]
(
    @OrgName       NVARCHAR(200),
    @OrgType       TINYINT,
    @GeoId         BIGINT,
    @OrgDesc       NVARCHAR(1000) = NULL,
    @IsActive      BIT = 1,
    @UserCreater   INT = NULL,

    @ResultCode    INT OUTPUT,
    @ResultMessage NVARCHAR(500) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    SET @ResultCode = 500;
    SET @ResultMessage = N'خطای داخلی در ثبت سازمان.';

    BEGIN TRY

        ---------------------------------------------------------
        -- Validation
        ---------------------------------------------------------
        IF NULLIF(LTRIM(RTRIM(@OrgName)), N'') IS NULL
        BEGIN
            SET @ResultCode = 400;
            SET @ResultMessage = N'نام سازمان الزامی است.';
            RETURN;
        END;

        IF @OrgType IS NULL OR @OrgType = 0
        BEGIN
            SET @ResultCode = 400;
            SET @ResultMessage = N'نوع سازمان معتبر نیست.';
            RETURN;
        END;

        IF @GeoId IS NULL OR @GeoId <= 0
        BEGIN
            SET @ResultCode = 400;
            SET @ResultMessage = N'موقعیت جغرافیایی الزامی است.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- بررسی Geo
        ---------------------------------------------------------
        IF NOT EXISTS
        (
            SELECT 1
            FROM dbo.Geo
            WHERE GeoId = @GeoId
        )
        BEGIN
            SET @ResultCode = 404;
            SET @ResultMessage = N'موقعیت جغرافیایی انتخاب شده وجود ندارد.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- بررسی تکراری بودن نام سازمان
        -- OrgName + OrgType + GeoId
        ---------------------------------------------------------
        IF EXISTS
        (
            SELECT 1
            FROM dbo.Organizations
            WHERE LTRIM(RTRIM(OrgName)) = LTRIM(RTRIM(@OrgName))
              AND OrgType = @OrgType
              AND GeoId = @GeoId
              AND ISNULL(IsDeleted, 0) = 0
        )
        BEGIN
            SET @ResultCode = 409;
            SET @ResultMessage =
                N'سازمانی با این نام، نوع سازمان و موقعیت جغرافیایی قبلاً ثبت شده است.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- Insert
        ---------------------------------------------------------
        INSERT INTO dbo.Organizations
        (
            OrgName,
            OrgType,
            GeoId,
            OrgDesc,
            IsActive,
            IsDeleted,
            CreatedAt,
            UserCreater
        )
        VALUES
        (
            LTRIM(RTRIM(@OrgName)),
            @OrgType,
            @GeoId,
            @OrgDesc,
            ISNULL(@IsActive, 1),
            0,
            GETDATE(),
            @UserCreater
        );

        SET @ResultCode = 200;
        SET @ResultMessage = N'سازمان با موفقیت ثبت شد.';

        SELECT
            O.*
        FROM dbo.Organizations AS O
        WHERE O.OrgId = SCOPE_IDENTITY();

    END TRY
    BEGIN CATCH

        SET @ResultCode = ERROR_NUMBER();
        SET @ResultMessage = ERROR_MESSAGE();

    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[OrganizationsDel]    Script Date: 9/11/2026 7:47:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* =========================================================
   OrganizationsDel
   ========================================================= */
CREATE   PROCEDURE [dbo].[OrganizationsDel]
(
    @OrgId       BIGINT,
    @UserUpdater INT = NULL,

    @ResultCode  INT OUTPUT,
    @ResultMessage NVARCHAR(500) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    SET @ResultCode = 500;
    SET @ResultMessage = N'خطای داخلی در حذف سازمان.';

    BEGIN TRY

        IF @OrgId IS NULL OR @OrgId <= 0
        BEGIN
            SET @ResultCode = 400;
            SET @ResultMessage = N'کد سازمان معتبر نیست.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- بررسی وجود سازمان
        ---------------------------------------------------------
        IF NOT EXISTS
        (
            SELECT 1
            FROM dbo.Organizations
            WHERE OrgId = @OrgId
              AND ISNULL(IsDeleted, 0) = 0
        )
        BEGIN
            SET @ResultCode = 404;
            SET @ResultMessage = N'سازمان مورد نظر یافت نشد.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- بررسی Buildings
        ---------------------------------------------------------
        IF EXISTS
        (
            SELECT 1
            FROM dbo.Buildings
            WHERE OrgId = @OrgId
              AND ISNULL(IsDeleted, 0) = 0
        )
        BEGIN
            SET @ResultCode = 409;
            SET @ResultMessage =
                N'امکان حذف سازمان وجود ندارد؛ ساختمان‌هایی به این سازمان متصل هستند.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- Soft Delete
        ---------------------------------------------------------
        UPDATE dbo.Organizations
        SET
            IsDeleted = 1,
            IsActive = 0,
            UpdatedAt = GETDATE(),
            UserUpdater = @UserUpdater
        WHERE OrgId = @OrgId;

        SET @ResultCode = 200;
        SET @ResultMessage = N'سازمان با موفقیت حذف شد.';

    END TRY
    BEGIN CATCH

        SET @ResultCode = ERROR_NUMBER();
        SET @ResultMessage = ERROR_MESSAGE();

    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[OrganizationsEdit]    Script Date: 9/11/2026 7:47:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* =========================================================
   OrganizationsEdit
   ========================================================= */
CREATE   PROCEDURE [dbo].[OrganizationsEdit]
(
    @OrgId         BIGINT,
    @OrgName       NVARCHAR(200),
    @OrgType       TINYINT,
    @GeoId         BIGINT,
    @OrgDesc       NVARCHAR(1000) = NULL,
    @IsActive      BIT = 1,
    @UserUpdater   INT = NULL,

    @ResultCode    INT OUTPUT,
    @ResultMessage NVARCHAR(500) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    SET @ResultCode = 500;
    SET @ResultMessage = N'خطای داخلی در ویرایش سازمان.';

    BEGIN TRY

        ---------------------------------------------------------
        -- Validation
        ---------------------------------------------------------
        IF @OrgId IS NULL OR @OrgId <= 0
        BEGIN
            SET @ResultCode = 400;
            SET @ResultMessage = N'کد سازمان معتبر نیست.';
            RETURN;
        END;

        IF NULLIF(LTRIM(RTRIM(@OrgName)), N'') IS NULL
        BEGIN
            SET @ResultCode = 400;
            SET @ResultMessage = N'نام سازمان الزامی است.';
            RETURN;
        END;

        IF @OrgType IS NULL OR @OrgType = 0
        BEGIN
            SET @ResultCode = 400;
            SET @ResultMessage = N'نوع سازمان معتبر نیست.';
            RETURN;
        END;

        IF @GeoId IS NULL OR @GeoId <= 0
        BEGIN
            SET @ResultCode = 400;
            SET @ResultMessage = N'موقعیت جغرافیایی الزامی است.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- بررسی سازمان
        ---------------------------------------------------------
        IF NOT EXISTS
        (
            SELECT 1
            FROM dbo.Organizations
            WHERE OrgId = @OrgId
              AND ISNULL(IsDeleted, 0) = 0
        )
        BEGIN
            SET @ResultCode = 404;
            SET @ResultMessage = N'سازمان مورد نظر یافت نشد.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- بررسی Geo
        ---------------------------------------------------------
        IF NOT EXISTS
        (
            SELECT 1
            FROM dbo.Geo
            WHERE GeoId = @GeoId
        )
        BEGIN
            SET @ResultCode = 404;
            SET @ResultMessage = N'موقعیت جغرافیایی انتخاب شده وجود ندارد.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- بررسی Duplicate
        ---------------------------------------------------------
        IF EXISTS
        (
            SELECT 1
            FROM dbo.Organizations
            WHERE LTRIM(RTRIM(OrgName)) = LTRIM(RTRIM(@OrgName))
              AND OrgType = @OrgType
              AND GeoId = @GeoId
              AND OrgId <> @OrgId
              AND ISNULL(IsDeleted, 0) = 0
        )
        BEGIN
            SET @ResultCode = 409;
            SET @ResultMessage =
                N'سازمان دیگری با همین نام، نوع سازمان و موقعیت جغرافیایی وجود دارد.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- Update
        ---------------------------------------------------------
        UPDATE dbo.Organizations
        SET
            OrgName = LTRIM(RTRIM(@OrgName)),
            OrgType = @OrgType,
            GeoId = @GeoId,
            OrgDesc = @OrgDesc,
            IsActive = ISNULL(@IsActive, 1),
            UpdatedAt = GETDATE(),
            UserUpdater = @UserUpdater
        WHERE OrgId = @OrgId;

        SET @ResultCode = 200;
        SET @ResultMessage = N'سازمان با موفقیت ویرایش شد.';

        SELECT
            O.*
        FROM dbo.Organizations AS O
        WHERE O.OrgId = @OrgId;

    END TRY
    BEGIN CATCH

        SET @ResultCode = ERROR_NUMBER();
        SET @ResultMessage = ERROR_MESSAGE();

    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[OrganizationsGet]    Script Date: 9/11/2026 7:47:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* =========================================================
   OrganizationsGet
   ========================================================= */
CREATE   PROCEDURE [dbo].[OrganizationsGet]
(
    @OrgId          BIGINT = NULL,
    @Search         NVARCHAR(200) = NULL,
    @OrgType        TINYINT = NULL,
    @GeoId          BIGINT = NULL,
    @PageNumber     INT = 1,
    @PageSize       INT = 50,
    @IncludeDeleted BIT = 0,

    @ResultCode     INT OUTPUT,
    @ResultMessage  NVARCHAR(500) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    SET @ResultCode = 500;
    SET @ResultMessage = N'خطای داخلی در دریافت سازمان‌ها.';

    BEGIN TRY

        SET @PageNumber = ISNULL(@PageNumber, 1);
        SET @PageSize = ISNULL(@PageSize, 50);
        SET @Search = NULLIF(LTRIM(RTRIM(@Search)), N'');

        IF @PageNumber < 1
            SET @PageNumber = 1;

        IF @PageSize < 1
            SET @PageSize = 50;

        IF @PageSize > 500
            SET @PageSize = 500;

        ---------------------------------------------------------
        -- دریافت یک سازمان
        ---------------------------------------------------------
        IF @OrgId IS NOT NULL
        BEGIN

            IF NOT EXISTS
            (
                SELECT 1
                FROM dbo.Organizations
                WHERE OrgId = @OrgId
                  AND
                  (
                      @IncludeDeleted = 1
                      OR ISNULL(IsDeleted, 0) = 0
                  )
            )
            BEGIN
                SET @ResultCode = 404;
                SET @ResultMessage = N'سازمان مورد نظر یافت نشد.';
                RETURN;
            END;

            SELECT
                O.*
            FROM dbo.Organizations AS O
            WHERE O.OrgId = @OrgId
              AND
              (
                  @IncludeDeleted = 1
                  OR ISNULL(O.IsDeleted, 0) = 0
              );

            SET @ResultCode = 200;
            SET @ResultMessage = N'اطلاعات سازمان با موفقیت دریافت شد.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- لیست سازمان‌ها
        ---------------------------------------------------------
        SELECT
            O.*
        FROM dbo.Organizations AS O
        WHERE
            (
                @IncludeDeleted = 1
                OR ISNULL(O.IsDeleted, 0) = 0
            )
            AND
            (
                @Search IS NULL
                OR O.OrgName LIKE N'%' + ISNULL(@Search, N'') + N'%'
            )
            AND
            (
                @OrgType IS NULL
                OR O.OrgType = @OrgType
            )
            AND
            (
                @GeoId IS NULL
                OR O.GeoId = @GeoId
            )
        ORDER BY O.OrgId DESC
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;

        SET @ResultCode = 200;
        SET @ResultMessage = N'لیست سازمان‌ها با موفقیت دریافت شد.';

    END TRY
    BEGIN CATCH

        SET @ResultCode = ERROR_NUMBER();
        SET @ResultMessage = ERROR_MESSAGE();

    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[UnitsAdd]    Script Date: 9/11/2026 7:47:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* =========================================================
   UnitsAdd
   ========================================================= */
CREATE   PROCEDURE [dbo].[UnitsAdd]
(
    @BuildingId       BIGINT,
    @UnitNumber       NVARCHAR(50),
    @FloorNumber      INT = NULL,
    @Area             DECIMAL(10,2) = NULL,
    @Bedrooms         TINYINT = NULL,
    @UnitDescription  NVARCHAR(1000) = NULL,
    @IsActive         BIT = 1,
    @UserCreater      INT = NULL,

    @ResultCode       INT OUTPUT,
    @ResultMessage    NVARCHAR(500) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    SET @ResultCode = 500;
    SET @ResultMessage = N'خطای داخلی در ثبت واحد.';

    BEGIN TRY

        ---------------------------------------------------------
        -- Validation
        ---------------------------------------------------------
        IF @BuildingId IS NULL OR @BuildingId <= 0
        BEGIN
            SET @ResultCode = 400;
            SET @ResultMessage = N'کد ساختمان معتبر نیست.';
            RETURN;
        END;

        IF NULLIF(LTRIM(RTRIM(@UnitNumber)), N'') IS NULL
        BEGIN
            SET @ResultCode = 400;
            SET @ResultMessage = N'شماره یا نام واحد الزامی است.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- بررسی Building
        ---------------------------------------------------------
        IF NOT EXISTS
        (
            SELECT 1
            FROM dbo.Buildings
            WHERE BuildingId = @BuildingId
              AND ISNULL(IsDeleted, 0) = 0
              AND IsActive = 1
        )
        BEGIN
            SET @ResultCode = 404;
            SET @ResultMessage =
                N'ساختمان انتخاب شده وجود ندارد، حذف شده یا غیرفعال است.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- بررسی Duplicate
        -- Building + Floor + UnitNumber
        ---------------------------------------------------------
        IF EXISTS
        (
            SELECT 1
            FROM dbo.Units
            WHERE BuildingId = @BuildingId
              AND ISNULL(FloorNumber, -999999) =
                  ISNULL(@FloorNumber, -999999)
              AND LTRIM(RTRIM(UnitNumber)) =
                  LTRIM(RTRIM(@UnitNumber))
              AND ISNULL(IsDeleted, 0) = 0
        )
        BEGIN
            SET @ResultCode = 409;
            SET @ResultMessage =
                N'در این طبقه از این ساختمان، واحدی با این شماره یا نام قبلاً ثبت شده است.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- Insert
        ---------------------------------------------------------
        INSERT INTO dbo.Units
        (
            BuildingId,
            UnitNumber,
            FloorNumber,
            Area,
            Bedrooms,
            UnitDescription,
            IsActive,
            IsDeleted,
            CreatedAt,
            UserCreater
        )
        VALUES
        (
            @BuildingId,
            LTRIM(RTRIM(@UnitNumber)),
            @FloorNumber,
            @Area,
            @Bedrooms,
            @UnitDescription,
            ISNULL(@IsActive, 1),
            0,
            GETDATE(),
            @UserCreater
        );

        SET @ResultCode = 200;
        SET @ResultMessage = N'واحد با موفقیت ثبت شد.';

        SELECT
            U.*
        FROM dbo.Units AS U
        WHERE U.UnitId = SCOPE_IDENTITY();

    END TRY
    BEGIN CATCH

        SET @ResultCode = ERROR_NUMBER();
        SET @ResultMessage = ERROR_MESSAGE();

    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[UnitsDel]    Script Date: 9/11/2026 7:47:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* =========================================================
   UnitsDel
   ========================================================= */
CREATE   PROCEDURE [dbo].[UnitsDel]
(
    @UnitId      BIGINT,
    @UserUpdater INT = NULL,

    @ResultCode  INT OUTPUT,
    @ResultMessage NVARCHAR(500) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    SET @ResultCode = 500;
    SET @ResultMessage = N'خطای داخلی در حذف واحد.';

    BEGIN TRY

        IF @UnitId IS NULL OR @UnitId <= 0
        BEGIN
            SET @ResultCode = 400;
            SET @ResultMessage = N'کد واحد معتبر نیست.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- بررسی وجود Unit
        ---------------------------------------------------------
        IF NOT EXISTS
        (
            SELECT 1
            FROM dbo.Units
            WHERE UnitId = @UnitId
              AND ISNULL(IsDeleted, 0) = 0
        )
        BEGIN
            SET @ResultCode = 404;
            SET @ResultMessage = N'واحد مورد نظر یافت نشد.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- Soft Delete
        ---------------------------------------------------------
        UPDATE dbo.Units
        SET
            IsDeleted = 1,
            IsActive = 0,
            UpdatedAt = GETDATE(),
            UserUpdater = @UserUpdater
        WHERE UnitId = @UnitId;

        SET @ResultCode = 200;
        SET @ResultMessage = N'واحد با موفقیت حذف شد.';

    END TRY
    BEGIN CATCH

        SET @ResultCode = ERROR_NUMBER();
        SET @ResultMessage = ERROR_MESSAGE();

    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[UnitsEdit]    Script Date: 9/11/2026 7:47:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* =========================================================
   UnitsEdit
   ========================================================= */
CREATE   PROCEDURE [dbo].[UnitsEdit]
(
    @UnitId           BIGINT,
    @BuildingId       BIGINT,
    @UnitNumber       NVARCHAR(50),
    @FloorNumber      INT = NULL,
    @Area             DECIMAL(10,2) = NULL,
    @Bedrooms         TINYINT = NULL,
    @UnitDescription  NVARCHAR(1000) = NULL,
    @IsActive         BIT = 1,
    @UserUpdater      INT = NULL,

    @ResultCode       INT OUTPUT,
    @ResultMessage    NVARCHAR(500) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    SET @ResultCode = 500;
    SET @ResultMessage = N'خطای داخلی در ویرایش واحد.';

    BEGIN TRY

        ---------------------------------------------------------
        -- Validation
        ---------------------------------------------------------
        IF @UnitId IS NULL OR @UnitId <= 0
        BEGIN
            SET @ResultCode = 400;
            SET @ResultMessage = N'کد واحد معتبر نیست.';
            RETURN;
        END;

        IF @BuildingId IS NULL OR @BuildingId <= 0
        BEGIN
            SET @ResultCode = 400;
            SET @ResultMessage = N'کد ساختمان معتبر نیست.';
            RETURN;
        END;

        IF NULLIF(LTRIM(RTRIM(@UnitNumber)), N'') IS NULL
        BEGIN
            SET @ResultCode = 400;
            SET @ResultMessage = N'شماره یا نام واحد الزامی است.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- بررسی Unit
        ---------------------------------------------------------
        IF NOT EXISTS
        (
            SELECT 1
            FROM dbo.Units
            WHERE UnitId = @UnitId
              AND ISNULL(IsDeleted, 0) = 0
        )
        BEGIN
            SET @ResultCode = 404;
            SET @ResultMessage = N'واحد مورد نظر یافت نشد.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- بررسی Building
        ---------------------------------------------------------
        IF NOT EXISTS
        (
            SELECT 1
            FROM dbo.Buildings
            WHERE BuildingId = @BuildingId
              AND ISNULL(IsDeleted, 0) = 0
              AND IsActive = 1
        )
        BEGIN
            SET @ResultCode = 404;
            SET @ResultMessage =
                N'ساختمان انتخاب شده وجود ندارد، حذف شده یا غیرفعال است.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- بررسی Duplicate
        ---------------------------------------------------------
        IF EXISTS
        (
            SELECT 1
            FROM dbo.Units
            WHERE BuildingId = @BuildingId
              AND ISNULL(FloorNumber, -999999) =
                  ISNULL(@FloorNumber, -999999)
              AND LTRIM(RTRIM(UnitNumber)) =
                  LTRIM(RTRIM(@UnitNumber))
              AND UnitId <> @UnitId
              AND ISNULL(IsDeleted, 0) = 0
        )
        BEGIN
            SET @ResultCode = 409;
            SET @ResultMessage =
                N'در این طبقه از این ساختمان، واحد دیگری با این شماره یا نام وجود دارد.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- Update
        ---------------------------------------------------------
        UPDATE dbo.Units
        SET
            BuildingId = @BuildingId,
            UnitNumber = LTRIM(RTRIM(@UnitNumber)),
            FloorNumber = @FloorNumber,
            Area = @Area,
            Bedrooms = @Bedrooms,
            UnitDescription = @UnitDescription,
            IsActive = ISNULL(@IsActive, 1),
            UpdatedAt = GETDATE(),
            UserUpdater = @UserUpdater
        WHERE UnitId = @UnitId;

        SET @ResultCode = 200;
        SET @ResultMessage = N'واحد با موفقیت ویرایش شد.';

        SELECT
            U.*
        FROM dbo.Units AS U
        WHERE U.UnitId = @UnitId;

    END TRY
    BEGIN CATCH

        SET @ResultCode = ERROR_NUMBER();
        SET @ResultMessage = ERROR_MESSAGE();

    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[UnitsGet]    Script Date: 9/11/2026 7:47:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* =========================================================
   UnitsGet
   ========================================================= */
CREATE   PROCEDURE [dbo].[UnitsGet]
(
    @UnitId         BIGINT = NULL,
    @BuildingId     BIGINT = NULL,
    @Search         NVARCHAR(50) = NULL,
    @FloorNumber    INT = NULL,
    @PageNumber     INT = 1,
    @PageSize       INT = 50,
    @IncludeDeleted BIT = 0,

    @ResultCode     INT OUTPUT,
    @ResultMessage  NVARCHAR(500) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    SET @ResultCode = 500;
    SET @ResultMessage = N'خطای داخلی در دریافت واحدها.';

    BEGIN TRY

        SET @PageNumber = ISNULL(@PageNumber, 1);
        SET @PageSize = ISNULL(@PageSize, 50);
        SET @Search = NULLIF(LTRIM(RTRIM(@Search)), N'');

        IF @PageNumber < 1
            SET @PageNumber = 1;

        IF @PageSize < 1
            SET @PageSize = 50;

        IF @PageSize > 500
            SET @PageSize = 500;

        ---------------------------------------------------------
        -- دریافت یک Unit
        ---------------------------------------------------------
        IF @UnitId IS NOT NULL
        BEGIN

            IF NOT EXISTS
            (
                SELECT 1
                FROM dbo.Units
                WHERE UnitId = @UnitId
                  AND
                  (
                      @IncludeDeleted = 1
                      OR ISNULL(IsDeleted, 0) = 0
                  )
            )
            BEGIN
                SET @ResultCode = 404;
                SET @ResultMessage = N'واحد مورد نظر یافت نشد.';
                RETURN;
            END;

            SELECT
                U.*
            FROM dbo.Units AS U
            WHERE U.UnitId = @UnitId
              AND
              (
                  @IncludeDeleted = 1
                  OR ISNULL(U.IsDeleted, 0) = 0
              );

            SET @ResultCode = 200;
            SET @ResultMessage = N'اطلاعات واحد با موفقیت دریافت شد.';
            RETURN;
        END;

        ---------------------------------------------------------
        -- لیست Units + Pagination
        ---------------------------------------------------------
        SELECT
            U.*
        FROM dbo.Units AS U
        WHERE
            (
                @IncludeDeleted = 1
                OR ISNULL(U.IsDeleted, 0) = 0
            )
            AND
            (
                @BuildingId IS NULL
                OR U.BuildingId = @BuildingId
            )
            AND
            (
                @FloorNumber IS NULL
                OR U.FloorNumber = @FloorNumber
            )
            AND
            (
                @Search IS NULL
                OR U.UnitNumber LIKE N'%' + ISNULL(@Search, N'') + N'%'
            )
        ORDER BY U.UnitId DESC
        OFFSET (@PageNumber - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY;

        SET @ResultCode = 200;
        SET @ResultMessage = N'لیست واحدها با موفقیت دریافت شد.';

    END TRY
    BEGIN CATCH

        SET @ResultCode = ERROR_NUMBER();
        SET @ResultMessage = ERROR_MESSAGE();

    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[UserLogin]    Script Date: 9/11/2026 7:47:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UserLogin]
(
    @pUsername       NVARCHAR(100),
    @pPasswordHash   NVARCHAR(500),

    @ResultCode     INT OUTPUT,
    @ResultMessage  NVARCHAR(500) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    ---------------------------------------------------------
    -- مقداردهی اولیه Output
    ---------------------------------------------------------
    SET @ResultCode = 500;
    SET @ResultMessage = N'خطای داخلی در انجام عملیات.';


    DECLARE @UserId BIGINT = NULL;
    DECLARE @IsActive BIT = NULL;


    ---------------------------------------------------------
    -- 1. بررسی ورودی
    ---------------------------------------------------------
    IF NULLIF(LTRIM(RTRIM(@pUsername)), N'') IS NULL
       OR NULLIF(LTRIM(RTRIM(@pPasswordHash)), N'') IS NULL
    BEGIN
        SET @ResultCode = 400;
        SET @ResultMessage = N'نام کاربری و رمز عبور الزامی است.';
        RETURN;
    END;


    ---------------------------------------------------------
    -- 2. پیدا کردن کاربر
    ---------------------------------------------------------
    SELECT TOP (1)
        @UserId = U.UserId,
        @IsActive = U.IsActive
    FROM dbo.Users AS U
    WHERE U.Username = @pUsername;


    ---------------------------------------------------------
    -- 3. کاربر وجود ندارد
    ---------------------------------------------------------
    IF @UserId IS NULL
    BEGIN
        SET @ResultCode = 404;
        SET @ResultMessage = N'کاربری با این نام کاربری یافت نشد.';
        RETURN;
    END;


    ---------------------------------------------------------
    -- 4. کاربر غیرفعال است
    ---------------------------------------------------------
    IF @IsActive = 0
    BEGIN
        SET @ResultCode = 403;
        SET @ResultMessage =
            N'حساب کاربری شما غیرفعال است. لطفاً با مدیر سیستم تماس بگیرید.';
        RETURN;
    END;


    ---------------------------------------------------------
    -- 5. بررسی رمز عبور
    ---------------------------------------------------------
    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Users AS U
        WHERE
            U.UserId = @UserId
            AND U.PasswordHash = @pPasswordHash
    )
    BEGIN
        SET @ResultCode = 401;
        SET @ResultMessage = N'رمز عبور وارد شده صحیح نیست.';
        RETURN;
    END;


    ---------------------------------------------------------
    -- 6. ورود موفق
    ---------------------------------------------------------
    UPDATE dbo.Users
    SET LastLoginAt = GETDATE()
    WHERE UserId = @UserId;


    SET @ResultCode = 200;
    SET @ResultMessage = N'ورود با موفقیت انجام شد.';


    ---------------------------------------------------------
    -- Result Set 1 : User
    ---------------------------------------------------------
    SELECT
        U.UserId,
        U.Username,
        U.FirstName,
        U.LastName,
        LTRIM(RTRIM(
            ISNULL(U.FirstName, N'') + N' ' +
            ISNULL(U.LastName, N'')
        )) AS FullName,
        U.Email,
        U.Mobile,
        U.NationalId,
        U.Gender,
        U.BirthDate,
        U.PhoneVerified,
        U.LastLoginAt,
        U.CreatedAt
    FROM dbo.Users AS U
    WHERE U.UserId = @UserId;


    ---------------------------------------------------------
    -- Result Set 2 : Roles
    ---------------------------------------------------------
    SELECT DISTINCT
        R.RoleId,
        R.RoleName,
        R.RoleDescription,
        UR.UserRoleId,
        UR.AssignedAt
    FROM dbo.UserRoles AS UR

    INNER JOIN dbo.Roles AS R
        ON R.RoleId = UR.RoleId

    WHERE
        UR.UserId = @UserId
        AND UR.IsActive = 1

    ORDER BY R.RoleName;


    ---------------------------------------------------------
    -- Result Set 3 : Menus + Permissions
    ---------------------------------------------------------
    SELECT
        M.MenuId,
        M.ParentId,
        M.Title,
        M.MenuUrl,
        M.Icon,
        M.SortOrder,
        M.MenuDescription,

        MAX(RM.PermissionLevel) AS PermissionLevel,

        CASE
            WHEN MAX(RM.PermissionLevel) >= 1
                THEN CAST(1 AS BIT)
            ELSE CAST(0 AS BIT)
        END AS CanRead,

        CASE
            WHEN MAX(RM.PermissionLevel) >= 2
                THEN CAST(1 AS BIT)
            ELSE CAST(0 AS BIT)
        END AS CanWrite,

        CASE
            WHEN MAX(RM.PermissionLevel) >= 3
                THEN CAST(1 AS BIT)
            ELSE CAST(0 AS BIT)
        END AS CanFullAccess

    FROM dbo.UserRoles AS UR

    INNER JOIN dbo.RoleMenus AS RM
        ON RM.RoleId = UR.RoleId

    INNER JOIN dbo.Menus AS M
        ON M.MenuId = RM.MenuId

    WHERE
        UR.UserId = @UserId
        AND UR.IsActive = 1
        AND RM.IsActive = 1
        AND M.IsActive = 1
        AND M.IsVisible = 1
        AND RM.PermissionLevel > 0

    GROUP BY
        M.MenuId,
        M.ParentId,
        M.Title,
        M.MenuUrl,
        M.Icon,
        M.SortOrder,
        M.MenuDescription

    ORDER BY M.SortOrder;

END;
GO
/****** Object:  StoredProcedure [dbo].[UsersCompleteProfile]    Script Date: 9/11/2026 7:47:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[UsersCompleteProfile]
(
    @UserId BIGINT,

    /* =========================
       Users
    ========================= */

    @FirstName NVARCHAR(100) = NULL,
    @LastName NVARCHAR(100) = NULL,
    @Email NVARCHAR(150) = NULL,
    @NationalId NVARCHAR(10) = NULL,
    @Gender INT = NULL,
    @BirthDate DATETIME = NULL,
    @AvatarUrl NVARCHAR(500) = NULL,

    /* =========================
       UserProfiles
    ========================= */

    @FatherName NVARCHAR(100) = NULL,
    @BirthPlace NVARCHAR(150) = NULL,
    @LandlinePhone NVARCHAR(30) = NULL,
    @UserPostalCode NVARCHAR(20) = NULL,
    @UserAddress NVARCHAR(500) = NULL,
    @EmergencyContactName NVARCHAR(200) = NULL,
    @EmergencyContactMobile NVARCHAR(30) = NULL,
    @EmergencyContactRelation NVARCHAR(100) = NULL,
    @ProfileNotes NVARCHAR(2000) = NULL,

    /* =========================
       UserResidencies
    ========================= */

    @UnitId BIGINT = NULL,
    @RelationshipType TINYINT = NULL,
    @StartDate DATETIME = NULL,
    @EndDate DATETIME = NULL,
    @ResidencyNotes NVARCHAR(1000) = NULL,

    @ResultCode INT OUTPUT,
    @ResultMessage NVARCHAR(500) OUTPUT
)
AS
BEGIN

    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    SET @ResultCode = 500;
    SET @ResultMessage = N'خطای نامشخص';


    BEGIN TRY

        /* =========================================
           User
        ========================================= */

        IF NOT EXISTS
        (
            SELECT 1
            FROM dbo.Users
            WHERE UserId = @UserId
              AND ISNULL(IsDeleted, 0) = 0
        )
        BEGIN
            SET @ResultCode = 404;
            SET @ResultMessage =
                N'کاربر پیدا نشد.';
            RETURN;
        END;


        /* =========================================
           Email Duplicate
        ========================================= */

        IF @Email IS NOT NULL
        AND EXISTS
        (
            SELECT 1
            FROM dbo.Users
            WHERE Email = @Email
              AND UserId <> @UserId
              AND ISNULL(IsDeleted, 0) = 0
        )
        BEGIN
            SET @ResultCode = 409;
            SET @ResultMessage =
                N'این ایمیل قبلاً توسط کاربر دیگری ثبت شده است.';
            RETURN;
        END;


        /* =========================================
           NationalId Duplicate
        ========================================= */

        IF @NationalId IS NOT NULL
        AND EXISTS
        (
            SELECT 1
            FROM dbo.Users
            WHERE NationalId = @NationalId
              AND UserId <> @UserId
              AND ISNULL(IsDeleted, 0) = 0
        )
        BEGIN
            SET @ResultCode = 409;
            SET @ResultMessage =
                N'این کد ملی قبلاً توسط کاربر دیگری ثبت شده است.';
            RETURN;
        END;


        /* =========================================
           Gender
        ========================================= */

        IF @Gender IS NOT NULL
           AND @Gender NOT IN (1,2)
        BEGIN
            SET @ResultCode = 400;
            SET @ResultMessage =
                N'مقدار جنسیت معتبر نیست.';
            RETURN;
        END;


        /* =========================================
           Unit
        ========================================= */

        IF @UnitId IS NOT NULL
        BEGIN

            IF NOT EXISTS
            (
                SELECT 1
                FROM dbo.Units
                WHERE UnitId = @UnitId
                  AND IsActive = 1
                  AND ISNULL(IsDeleted, 0) = 0
            )
            BEGIN
                SET @ResultCode = 404;
                SET @ResultMessage =
                    N'واحد انتخاب شده معتبر نیست.';
                RETURN;
            END;


            IF @RelationshipType IS NULL
            BEGIN
                SET @ResultCode = 400;
                SET @ResultMessage =
                    N'نوع رابطه با واحد الزامی است.';
                RETURN;
            END;


            IF @RelationshipType NOT BETWEEN 1 AND 5
            BEGIN
                SET @ResultCode = 400;
                SET @ResultMessage =
                    N'نوع رابطه با واحد معتبر نیست.';
                RETURN;
            END;

        END;


        BEGIN TRANSACTION;


        /* =========================================
           Update Users
           
           COALESCE:
           اگر ورودی NULL بود مقدار قبلی حفظ می‌شود.
        ========================================= */

        UPDATE dbo.Users
        SET
            FirstName =
                COALESCE(@FirstName, FirstName),

            LastName =
                COALESCE(@LastName, LastName),

            Email =
                COALESCE(@Email, Email),

            NationalId =
                COALESCE(@NationalId, NationalId),

            Gender =
                COALESCE(@Gender, Gender),

            BirthDate =
                COALESCE(@BirthDate, BirthDate),

            AvatarUrl =
                COALESCE(@AvatarUrl, AvatarUrl),

            UpdatedAt = GETDATE(),

            UserUpdater = @UserId

        WHERE UserId = @UserId;


        /* =========================================
           UserProfiles
        ========================================= */

        IF EXISTS
        (
            SELECT 1
            FROM dbo.UserProfiles
            WHERE UserId = @UserId
        )
        BEGIN

            UPDATE dbo.UserProfiles
            SET
                FatherName =
                    COALESCE(@FatherName, FatherName),

                BirthPlace =
                    COALESCE(@BirthPlace, BirthPlace),

                LandlinePhone =
                    COALESCE(@LandlinePhone, LandlinePhone),

                UserPostalCode =
                    COALESCE(@UserPostalCode, UserPostalCode),

                UserAddress =
                    COALESCE(@UserAddress, UserAddress),

                EmergencyContactName =
                    COALESCE(
                        @EmergencyContactName,
                        EmergencyContactName
                    ),

                EmergencyContactMobile =
                    COALESCE(
                        @EmergencyContactMobile,
                        EmergencyContactMobile
                    ),

                EmergencyContactRelation =
                    COALESCE(
                        @EmergencyContactRelation,
                        EmergencyContactRelation
                    ),

                Notes =
                    COALESCE(@ProfileNotes, Notes),

                UpdatedAt = GETDATE(),

                UserUpdater = @UserId

            WHERE UserId = @UserId;

        END
        ELSE
        BEGIN

            INSERT INTO dbo.UserProfiles
            (
                UserId,
                FatherName,
                BirthPlace,
                LandlinePhone,
                UserPostalCode,
                UserAddress,
                EmergencyContactName,
                EmergencyContactMobile,
                EmergencyContactRelation,
                Notes,
                CreatedAt,
                UserCreater
            )
            VALUES
            (
                @UserId,
                @FatherName,
                @BirthPlace,
                @LandlinePhone,
                @UserPostalCode,
                @UserAddress,
                @EmergencyContactName,
                @EmergencyContactMobile,
                @EmergencyContactRelation,
                @ProfileNotes,
                GETDATE(),
                @UserId
            );

        END;


        /* =========================================
           Residency
        ========================================= */

        IF @UnitId IS NOT NULL
        BEGIN

            /*
                اگر قبلاً همین واحد برای این کاربر
                وجود نداشته باشد ایجاد می‌کنیم.
            */

            IF EXISTS
            (
                SELECT 1
                FROM dbo.UserResidencies
                WHERE UserId = @UserId
                  AND UnitId = @UnitId
                  AND ISNULL(IsDeleted, 0) = 0
            )
            BEGIN

                UPDATE dbo.UserResidencies
                SET
                    RelationshipType =
                        COALESCE(
                            @RelationshipType,
                            RelationshipType
                        ),

                    StartDate =
                        COALESCE(@StartDate, StartDate),

                    EndDate =
                        COALESCE(@EndDate, EndDate),

                    Notes =
                        COALESCE(
                            @ResidencyNotes,
                            Notes
                        ),

                    IsActive = 1,

                    UpdatedAt = GETDATE(),

                    UserUpdater = @UserId

                WHERE UserId = @UserId
                  AND UnitId = @UnitId
                  AND ISNULL(IsDeleted, 0) = 0;

            END
            ELSE
            BEGIN

                INSERT INTO dbo.UserResidencies
                (
                    UserId,
                    UnitId,
                    RelationshipType,
                    StartDate,
                    EndDate,
                    IsActive,
                    IsDeleted,
                    Notes,
                    CreatedAt,
                    UserCreater
                )
                VALUES
                (
                    @UserId,
                    @UnitId,
                    @RelationshipType,
                    @StartDate,
                    @EndDate,
                    1,
                    0,
                    @ResidencyNotes,
                    GETDATE(),
                    @UserId
                );

            END;

        END;


        COMMIT TRANSACTION;


        SET @ResultCode = 200;
        SET @ResultMessage =
            N'اطلاعات پروفایل با موفقیت ثبت شد.';


        SELECT
            U.UserId,
            U.Username,
            U.Email,
            U.Mobile,
            U.FirstName,
            U.LastName,
            U.NationalId,
            U.Gender,
            U.BirthDate,
            U.AvatarUrl,
            U.PhoneVerified,
            U.IsActive
        FROM dbo.Users U
        WHERE U.UserId = @UserId;


        SELECT
            P.*
        FROM dbo.UserProfiles P
        WHERE P.UserId = @UserId;


        SELECT
            R.*
        FROM dbo.UserResidencies R
        WHERE R.UserId = @UserId
          AND ISNULL(R.IsDeleted, 0) = 0;


        RETURN;

    END TRY
    BEGIN CATCH

        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        SET @ResultCode = 500;
        SET @ResultMessage =
            N'خطا در تکمیل اطلاعات کاربر: '
            + ERROR_MESSAGE();

        RETURN;

    END CATCH

END;
GO
/****** Object:  StoredProcedure [dbo].[UsersOtpVerify]    Script Date: 9/11/2026 7:47:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[UsersOtpVerify]
(
    @UserId             BIGINT,
    @OtpRequestId       BIGINT,
    @OtpCode            VARCHAR(6),

    @RoleId             BIGINT = NULL,

    @UnitId             BIGINT = NULL,
    @RelationshipType   TINYINT = NULL,
    @StartDate          DATETIME = NULL,
    @EndDate            DATETIME = NULL,

    @ResultCode         INT OUTPUT,
    @ResultMessage      NVARCHAR(500) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    SET @ResultCode = 500;
    SET @ResultMessage = N'خطای نامشخص';

    DECLARE @Now DATETIME2(0) = SYSDATETIME(),
        @StoredOtpCode NVARCHAR(10),
        @ExpiresAt DATETIME2(0),
        @AttemptCount INT,
        @MaxAttempts INT,
        @IsUsed BIT,
        @IsBlocked BIT,
        @Mobile NVARCHAR(30),
        @UserExists BIT = 0;


    BEGIN TRY

        /* =========================================
           Validation
        ========================================= */

        IF @UserId IS NULL
           OR @OtpRequestId IS NULL
           OR @OtpCode IS NULL
        BEGIN
            SET @ResultCode = 400;
            SET @ResultMessage =
                N'اطلاعات تایید OTP ناقص است.';
            RETURN;
        END;


        IF LEN(@OtpCode) <> 6
        BEGIN
            SET @ResultCode = 400;
            SET @ResultMessage =
                N'کد تایید باید 6 رقمی باشد.';
            RETURN;
        END;


        /* =========================================
           User
        ========================================= */

        SELECT
            @UserExists = 1,
            @Mobile = Mobile
        FROM dbo.Users
        WHERE UserId = @UserId
          AND ISNULL(IsDeleted, 0) = 0;


        IF @UserExists = 0
        BEGIN
            SET @ResultCode = 404;
            SET @ResultMessage =
                N'کاربر پیدا نشد.';
            RETURN;
        END;


        /* =========================================
           OTP
        ========================================= */

        SELECT
            @StoredOtpCode = OtpCode,
            @ExpiresAt = ExpiresAt,
            @AttemptCount = AttemptCount,
            @MaxAttempts = MaxAttempts,
            @IsUsed = IsUsed,
            @IsBlocked = IsBlocked
        FROM dbo.UserOtpRequests
        WHERE OtpRequestId = @OtpRequestId
          AND UserId = @UserId
          AND Mobile = @Mobile
          AND OtpPurpose = N'SIGNUP';


        IF @StoredOtpCode IS NULL
        BEGIN
            SET @ResultCode = 404;
            SET @ResultMessage =
                N'کد تایید پیدا نشد.';
            RETURN;
        END;


        IF @IsUsed = 1
        BEGIN
            SET @ResultCode = 409;
            SET @ResultMessage =
                N'این کد قبلاً استفاده شده است.';
            RETURN;
        END;


        IF @IsBlocked = 1
        BEGIN
            SET @ResultCode = 429;
            SET @ResultMessage =
                N'این کد دیگر قابل استفاده نیست.';
            RETURN;
        END;


        IF @ExpiresAt <= @Now
        BEGIN
            SET @ResultCode = 410;
            SET @ResultMessage =
                N'کد تایید منقضی شده است.';
            RETURN;
        END;


        IF @AttemptCount >= @MaxAttempts
        BEGIN

            UPDATE dbo.UserOtpRequests
            SET IsBlocked = 1
            WHERE OtpRequestId = @OtpRequestId;

            SET @ResultCode = 429;
            SET @ResultMessage =
                N'تعداد تلاش‌های مجاز برای این کد به پایان رسیده است.';
            RETURN;
        END;


        /* =========================================
           Calculate Hash
        ========================================= */

        --SET @OtpCode = '1234'
            


        /* =========================================
           Wrong OTP
        ========================================= */

        IF @OtpCode <> @StoredOtpCode
        BEGIN

            UPDATE dbo.UserOtpRequests
            SET
                AttemptCount = AttemptCount + 1,
                IsBlocked =
                    CASE
                        WHEN AttemptCount + 1 >= MaxAttempts
                        THEN 1
                        ELSE 0
                    END
            WHERE OtpRequestId = @OtpRequestId;

            SET @ResultCode = 401;
            SET @ResultMessage =
                N'کد تایید صحیح نیست.';
            RETURN;
        END;


        /* =========================================
           Role Validation
        ========================================= */

        IF @RoleId IS NOT NULL
        BEGIN

            IF NOT EXISTS
            (
                SELECT 1
                FROM dbo.Roles
                WHERE RoleId = @RoleId
            )
            BEGIN
                SET @ResultCode = 404;
                SET @ResultMessage =
                    N'نقش انتخاب شده وجود ندارد.';
                RETURN;
            END;

        END;


        /* =========================================
           Unit Validation
        ========================================= */

        IF @UnitId IS NOT NULL
        BEGIN

            IF NOT EXISTS
            (
                SELECT 1
                FROM dbo.Units
                WHERE UnitId = @UnitId
                  AND IsActive = 1
                  AND ISNULL(IsDeleted, 0) = 0
            )
            BEGIN
                SET @ResultCode = 404;
                SET @ResultMessage =
                    N'واحد انتخاب شده وجود ندارد یا فعال نیست.';
                RETURN;
            END;


            IF @RelationshipType IS NULL
            BEGIN
                SET @ResultCode = 400;
                SET @ResultMessage =
                    N'نوع رابطه با واحد الزامی است.';
                RETURN;
            END;


            IF @RelationshipType NOT BETWEEN 1 AND 5
            BEGIN
                SET @ResultCode = 400;
                SET @ResultMessage =
                    N'نوع رابطه با واحد معتبر نیست.';
                RETURN;
            END;

        END;


        BEGIN TRANSACTION;


        /* =========================================
           Mark OTP Used
        ========================================= */

        UPDATE dbo.UserOtpRequests
        SET
            IsUsed = 1,
            VerifiedAt = @Now
        WHERE OtpRequestId = @OtpRequestId
          AND IsUsed = 0
          AND IsBlocked = 0;


        IF @@ROWCOUNT <> 1
        BEGIN
            ROLLBACK TRANSACTION;

            SET @ResultCode = 409;
            SET @ResultMessage =
                N'این درخواست OTP دیگر قابل استفاده نیست.';
            RETURN;
        END;


        /* =========================================
           Activate User
        ========================================= */

        UPDATE dbo.Users
        SET
            PhoneVerified = 1,
            IsActive = 1,
            IsDeleted = 0,
            UpdatedAt = GETDATE(),
            UserUpdater = NULL
        WHERE UserId = @UserId;


        /* =========================================
           Default UserProfile
        ========================================= */

        IF NOT EXISTS
        (
            SELECT 1
            FROM dbo.UserProfiles
            WHERE UserId = @UserId
        )
        BEGIN

            INSERT INTO dbo.UserProfiles
            (
                UserId,
                FatherName,
                BirthPlace,
                LandlinePhone,
                UserPostalCode,
                UserAddress,
                EmergencyContactName,
                EmergencyContactMobile,
                EmergencyContactRelation,
                Notes,
                CreatedAt,
                UserCreater
            )
            VALUES
            (
                @UserId,
                NULL,
                NULL,
                NULL,
                NULL,
                NULL,
                NULL,
                NULL,
                NULL,
                NULL,
                GETDATE(),
                NULL
            );

        END;


        /* =========================================
           User Role
        ========================================= */

        IF @RoleId IS NOT NULL
        BEGIN

            IF NOT EXISTS
            (
                SELECT 1
                FROM dbo.UserRoles
                WHERE UserId = @UserId
                  AND RoleId = @RoleId
            )
            BEGIN

                INSERT INTO dbo.UserRoles
                (
                    UserId,
                    RoleId,
                    AssignedAt,
                    ExpiresAt,
                    IsActive,
                    IsDeleted,
                    CreatedAt,
                    UserCreater,
                    Notes
                )
                VALUES
                (
                    @UserId,
                    @RoleId,
                    GETDATE(),
                    NULL,
                    1,
                    0,
                    GETDATE(),
                    NULL,
                    N'Assigned during signup'
                );

            END;

        END;


        /* =========================================
           User Residency
        ========================================= */

        IF @UnitId IS NOT NULL
        BEGIN

            INSERT INTO dbo.UserResidencies
            (
                UserId,
                UnitId,
                RelationshipType,
                StartDate,
                EndDate,
                IsActive,
                IsDeleted,
                Notes,
                CreatedAt,
                UserCreater
            )
            VALUES
            (
                @UserId,
                @UnitId,
                @RelationshipType,
                @StartDate,
                @EndDate,
                1,
                0,
                NULL,
                GETDATE(),
                NULL
            );

        END;


        COMMIT TRANSACTION;


        SET @ResultCode = 200;
        SET @ResultMessage =
            N'ثبت نام با موفقیت انجام شد.';

        /* اطلاعات مناسب برای ساخت Session/JWT */

        SELECT
            U.UserId,
            U.Username,
            U.Email,
            U.Mobile,
            U.FirstName,
            U.LastName,
            U.Gender,
            U.PhoneVerified,
            U.IsActive
        FROM dbo.Users U
        WHERE U.UserId = @UserId;

        RETURN;

    END TRY
    BEGIN CATCH

        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        SET @ResultCode = 500;
        SET @ResultMessage =
            N'خطا در تایید ثبت نام: '
            + ERROR_MESSAGE();

        RETURN;

    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[UsersSignup]    Script Date: 9/11/2026 7:47:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[UsersSignup]
(
    @Mobile             NVARCHAR(30),
    @Username           NVARCHAR(100) = NULL,
    @PasswordHash       NVARCHAR(500) = NULL,

    @FirstName          NVARCHAR(100) = NULL,
    @LastName           NVARCHAR(100) = NULL,
    @Gender             INT = 0,

    @Email              NVARCHAR(150) = NULL,
    @NationalId         NVARCHAR(10) = NULL,
    @BirthDate          DATETIME = NULL,

    @RoleId             BIGINT = NULL,

    @RequestIp          NVARCHAR(50) = NULL,
    @UserAgent          NVARCHAR(500) = NULL,

    @ResultCode         INT OUTPUT,
    @ResultMessage      NVARCHAR(500) OUTPUT,

    @UserId             BIGINT OUTPUT,
    @OtpRequestId       BIGINT OUTPUT,
    @OtpCode            VARCHAR(6) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    SET @ResultCode = 500;
    SET @ResultMessage = N'خطای نامشخص';
    SET @UserId = NULL;
    SET @OtpRequestId = NULL;
    SET @OtpCode = NULL;

    DECLARE
        @Now DATETIME2(0) = SYSDATETIME(),
        @OtpExpiresAt DATETIME2(0),
        @NormalizedMobile NVARCHAR(30),
        @OtpCodeInt INT,
        @ExistingUserId BIGINT,
        @ExistingOtpRequestId BIGINT,
        @LastOtpCreatedAt DATETIME2(0),
        @OtpCount15Min INT,
        @DailyOtpCount INT,
        @RateLimitId BIGINT;

    BEGIN TRY

        /* =========================================
           Validation
        ========================================= */

        SET @NormalizedMobile =
            REPLACE(
                REPLACE(
                    REPLACE(
                        REPLACE(LTRIM(RTRIM(@Mobile)), N' ', N''),
                    N'-', N''),
                N'(', N''),
            N')', N'');

        SET @Username = NULLIF(LTRIM(RTRIM(@Username)), N'');
        SET @Email = NULLIF(LTRIM(RTRIM(@Email)), N'');
        SET @NationalId = NULLIF(LTRIM(RTRIM(@NationalId)), N'');

        SET @FirstName =
            ISNULL(NULLIF(LTRIM(RTRIM(@FirstName)), N''), N'کاربر');

        SET @LastName =
            ISNULL(NULLIF(LTRIM(RTRIM(@LastName)), N''), N'جدید');


        IF @NormalizedMobile IS NULL
           OR LEN(@NormalizedMobile) < 10
        BEGIN
            SET @ResultCode = 400;
            SET @ResultMessage = N'شماره موبایل معتبر نیست.';
            RETURN;
        END;


        /*
            حداقل یکی از این دو روش باید وجود داشته باشد:
            1- Username + Password
            2- Mobile OTP
        */

        IF @Username IS NOT NULL
           AND @PasswordHash IS NULL
        BEGIN
            SET @ResultCode = 400;
            SET @ResultMessage =
                N'برای ثبت نام با نام کاربری، کلمه عبور الزامی است.';
            RETURN;
        END;


        IF @Username IS NOT NULL
           AND LEN(@Username) < 3
        BEGIN
            SET @ResultCode = 400;
            SET @ResultMessage =
                N'نام کاربری باید حداقل 3 کاراکتر باشد.';
            RETURN;
        END;


        /*
            PasswordHash باید توسط API تولید شده باشد.
            SQL نباید Password خام دریافت کند.
        */

        IF @Username IS NOT NULL
           AND LEN(@PasswordHash) < 20
        BEGIN
            SET @ResultCode = 400;
            SET @ResultMessage =
                N'PasswordHash معتبر نیست.';
            RETURN;
        END;


        /* =========================================
           Username Duplicate
        ========================================= */

        IF @Username IS NOT NULL
        BEGIN
            SELECT TOP 1
                @ExistingUserId = UserId
            FROM dbo.Users
            WHERE Username = @Username
              AND ISNULL(IsDeleted, 0) = 0;

            IF @ExistingUserId IS NOT NULL
            BEGIN
                SET @ResultCode = 409;
                SET @ResultMessage =
                    N'این نام کاربری قبلاً ثبت شده است.';
                RETURN;
            END;
        END;


        /* =========================================
           Email Duplicate
        ========================================= */

        IF @Email IS NOT NULL
        BEGIN
            IF EXISTS
            (
                SELECT 1
                FROM dbo.Users
                WHERE Email = @Email
                  AND ISNULL(IsDeleted, 0) = 0
            )
            BEGIN
                SET @ResultCode = 409;
                SET @ResultMessage =
                    N'این ایمیل قبلاً ثبت شده است.';
                RETURN;
            END;
        END;


        /* =========================================
           NationalId Duplicate
        ========================================= */

        IF @NationalId IS NOT NULL
        BEGIN
            IF EXISTS
            (
                SELECT 1
                FROM dbo.Users
                WHERE NationalId = @NationalId
                  AND ISNULL(IsDeleted, 0) = 0
            )
            BEGIN
                SET @ResultCode = 409;
                SET @ResultMessage =
                    N'این کد ملی قبلاً ثبت شده است.';
                RETURN;
            END;
        END;


        /* =========================================
           User exists with this Mobile
        ========================================= */

        SELECT TOP 1
            @ExistingUserId = UserId
        FROM dbo.Users
        WHERE Mobile = @NormalizedMobile
          AND ISNULL(IsDeleted, 0) = 0
        ORDER BY UserId DESC;


        /*
            اگر User فعال و تایید شده باشد،
            نباید دوباره Signup انجام شود.
        */

        IF @ExistingUserId IS NOT NULL
        BEGIN
            IF EXISTS
            (
                SELECT 1
                FROM dbo.Users
                WHERE UserId = @ExistingUserId
                  AND IsActive = 1
                  AND PhoneVerified = 1
            )
            BEGIN
                SET @ResultCode = 409;
                SET @ResultMessage =
                    N'این شماره موبایل قبلاً ثبت نام کرده است.';
                RETURN;
            END;
        END;


        /* =========================================
           Rate Limit
        ========================================= */

        SELECT
            @RateLimitId = RateLimitId,
            @LastOtpCreatedAt = LastRequestAt,
            @DailyOtpCount = DailyCount
        FROM dbo.UserOtpRateLimits
        WHERE Mobile = @NormalizedMobile;


        /* اگر کمتر از 60 ثانیه گذشته باشد */

        IF @LastOtpCreatedAt IS NOT NULL
           AND DATEDIFF(SECOND, @LastOtpCreatedAt, @Now) < 60
        BEGIN
            SET @ResultCode = 429;
            SET @ResultMessage =
                N'لطفاً حداقل 60 ثانیه برای ارسال مجدد کد صبر کنید.';
            RETURN;
        END;


        /* حداکثر 20 SMS در روز */

        IF ISNULL(@DailyOtpCount, 0) >= 20
        BEGIN
            SET @ResultCode = 429;
            SET @ResultMessage =
                N'تعداد درخواست‌های OTP این شماره برای امروز بیش از حد مجاز است.';
            RETURN;
        END;


        /* =========================================
           15 Minute Rate Limit
        ========================================= */

        SELECT
            @OtpCount15Min = COUNT(*)
        FROM dbo.UserOtpRequests
        WHERE Mobile = @NormalizedMobile
          AND CreatedAt >= DATEADD(MINUTE, -15, @Now);


        IF @OtpCount15Min >= 5
        BEGIN
            SET @ResultCode = 429;
            SET @ResultMessage =
                N'تعداد درخواست‌های OTP بیش از حد مجاز است. لطفاً بعداً تلاش کنید.';
            RETURN;
        END;


        /* =========================================
           Generate OTP
        ========================================= */

        SET @OtpCodeInt =
            ABS(CHECKSUM(NEWID())) % 900000 + 100000;

        SET @OtpCode =
            RIGHT('000000' + CAST(@OtpCodeInt AS VARCHAR(6)), 6);

        SET @OtpExpiresAt =
            DATEADD(MINUTE, 2, @Now);


        BEGIN TRANSACTION;


        /* =========================================
           اگر User موقت قبلاً وجود دارد
           همان را استفاده می‌کنیم
        ========================================= */

        IF @ExistingUserId IS NULL
        BEGIN

            INSERT INTO dbo.Users
            (
                Username,
                PasswordHash,
                Email,
                Mobile,
                FirstName,
                LastName,
                NationalId,
                Gender,
                BirthDate,
                AvatarUrl,
                PhoneVerified,
                LastLoginAt,
                IsActive,
                IsDeleted,
                CreatedAt,
                UserCreater
            )
            VALUES
            (
                @Username,
                @PasswordHash,
                @Email,
                @NormalizedMobile,
                @FirstName,
                @LastName,
                @NationalId,
                @Gender,
                @BirthDate,
                NULL,
                0,
                NULL,
                0,
                0,
                GETDATE(),
                NULL
            );

            SET @UserId = CONVERT(BIGINT, SCOPE_IDENTITY());

        END
        ELSE
        BEGIN

            SET @UserId = @ExistingUserId;

            /*
                اطلاعات Signup جدید روی User موقت
                به‌روزرسانی می‌شود.
            */

            UPDATE dbo.Users
            SET
                Username = @Username,
                PasswordHash = @PasswordHash,
                Email = @Email,
                FirstName = @FirstName,
                LastName = @LastName,
                NationalId = @NationalId,
                Gender = @Gender,
                BirthDate = @BirthDate,
                PhoneVerified = 0,
                IsActive = 0,
                UpdatedAt = GETDATE(),
                UserUpdater = NULL
            WHERE UserId = @UserId;

        END;


        /* =========================================
           OTP قبلی را باطل کن
        ========================================= */

        UPDATE dbo.UserOtpRequests
        SET
            IsBlocked = 1
        WHERE UserId = @UserId
          AND OtpPurpose = 1
          AND IsUsed = 0
          AND IsBlocked = 0;


        /* =========================================
           ذخیره OTP Hash
           
           SHA2_512 => 64 bytes
        ========================================= */

        INSERT INTO dbo.UserOtpRequests
        (
            UserId,
            Mobile,
            OtpPurpose,
            OtpCode,
            CreatedAt,
            ExpiresAt,
            VerifiedAt,
            AttemptCount,
            MaxAttempts,
            IsUsed,
            IsBlocked,
            RequestIp,
            UserAgent
        )
        VALUES
        (
            @UserId,
            @NormalizedMobile,
            1,
            '1234',
            @Now,
            @OtpExpiresAt,
            NULL,
            0,
            5,
            0,
            0,
            @RequestIp,
            @UserAgent
        );


        SET @OtpRequestId =
            CONVERT(BIGINT, SCOPE_IDENTITY());


        /* =========================================
           Rate Limit Record
        ========================================= */

        IF @RateLimitId IS NULL
        BEGIN

            INSERT INTO dbo.UserOtpRateLimits
            (
                Mobile,
                WindowStart,
                RequestCount,
                DailyDate,
                DailyCount,
                BlockedUntil,
                LastRequestAt
            )
            VALUES
            (
                @NormalizedMobile,
                @Now,
                1,
                CONVERT(DATE, @Now),
                1,
                NULL,
                @Now
            );

        END
        ELSE
        BEGIN

            UPDATE dbo.UserOtpRateLimits
            SET
                RequestCount =
                    CASE
                        WHEN WindowStart < DATEADD(MINUTE, -15, @Now)
                        THEN 1
                        ELSE RequestCount + 1
                    END,

                WindowStart =
                    CASE
                        WHEN WindowStart < DATEADD(MINUTE, -15, @Now)
                        THEN @Now
                        ELSE WindowStart
                    END,

                DailyCount =
                    CASE
                        WHEN DailyDate <> CONVERT(DATE, @Now)
                        THEN 1
                        ELSE DailyCount + 1
                    END,

                DailyDate =
                    CONVERT(DATE, @Now),

                LastRequestAt = @Now,

                BlockedUntil = NULL

            WHERE RateLimitId = @RateLimitId;

        END;


        COMMIT TRANSACTION;


        SET @ResultCode = 200;
        SET @ResultMessage =
            N'کد تایید با موفقیت ایجاد شد.';

        /*
            API باید @OtpCode را دریافت کند
            و آن را از طریق SMS Provider ارسال کند.
        */

        SELECT
            @UserId AS UserId,
            @OtpRequestId AS OtpRequestId,
            @OtpCode AS OtpCode,
            @OtpExpiresAt AS OtpExpiresAt;

        RETURN;

    END TRY
    BEGIN CATCH

        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        SET @ResultCode = 500;
        SET @ResultMessage =
            N'خطا در ایجاد ثبت نام: '
            + ERROR_MESSAGE();

        SET @UserId = NULL;
        SET @OtpRequestId = NULL;
        SET @OtpCode = NULL;

        RETURN;

    END CATCH
END;
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد ساختمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'BuildingId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام ساختمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'BuildingName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ادرس ساختمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'BuildingAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات ساختمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'BuildingDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال است (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده؟ (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد سازمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Buildings', @level2type=N'COLUMN',@level2name=N'OrgId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد محل خدمت پرسنل' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'EmployeeAssignmentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد استخدامی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'EmployeeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد سازمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'OrgId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد ساختمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'BuildingId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد مکان ورزشی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'SpaceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ شروع' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'StartDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ خاتمه' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام شیفت' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'ShiftName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال است (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده؟ (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات محل خدمت پرسنل' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'EmployeeAssignmentDesc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'محل خدمت پرسنل' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeAssignments'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد استخدامی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'EmployeeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد کاربر' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد سازمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'OrgId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع استخدامی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'EmployeeTypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نحوه استخدامی (1: تمام وقت | 2: پاره وقت | 3: ساعتی | 4: قراردادی | 5: پروژه‌ای)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'EmploymentType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ استخدام' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'HireDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ پایان استخدام' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حقوق پایه' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'BaseSalary'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نرخ کار ساعتی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'HourlyRate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام بانک' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'BankName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شماره کارت بانک' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'BankCardNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شماره حساب بانک' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'BankAccountNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شماره شبا بانک' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'ShebaNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال است (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده؟ (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات کارمند' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'EmployeesDesc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد نوع استخدام' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'EmployeeTypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام نوع استخدام' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'EmployeeTypeName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیح نوع استخدام' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'EmployeeTypeDesc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال است (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده؟ (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EmployeeTypes', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد موقعیت جغرافیایی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Geo', @level2type=N'COLUMN',@level2name=N'GeoId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام موقعیت جغرافیایی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Geo', @level2type=N'COLUMN',@level2name=N'GeoName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'والد موقعیت جغرافیایی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Geo', @level2type=N'COLUMN',@level2name=N'ParantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'والد استان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Geo', @level2type=N'COLUMN',@level2name=N'PL1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'والد شهرستان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Geo', @level2type=N'COLUMN',@level2name=N'PL2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'والد بخش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Geo', @level2type=N'COLUMN',@level2name=N'PL3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'والد شهر' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Geo', @level2type=N'COLUMN',@level2name=N'PL4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'والد روستا' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Geo', @level2type=N'COLUMN',@level2name=N'PL5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'مسیبر موقعیت جغرافیایی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Geo', @level2type=N'COLUMN',@level2name=N'GeoPath'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'موقعیت جغرافیایی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Geo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد منو' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'MenuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد والد منو' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام منو' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'لینک منو' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'MenuUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'آیکون منو' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'Icon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شماره ردیف' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'SortOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات منو' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'MenuDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نمایش داده شود(1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'IsVisible'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال است (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده؟ (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد سازمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'OrgId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام سازمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'OrgName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع سازمان (1: ساختمان | 2: آموزشگاه | 3: باشگاه | 4: موسسه آموزشی | 5: مجتمع چندمنظوره | 99: سایر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'OrgType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد موقعیت جغرافیایی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'GeoId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات سازمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'OrgDesc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال است (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده؟ (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سازمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد نقش منو' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'RoleMenuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد نقش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'RoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد منو' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'MenuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'سطح دسترسی (1: بدون دسترسی 2: خواندن 3: نوشتن 4: کامل)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'PermissionLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال است (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده؟ (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleMenus', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد نقش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Roles', @level2type=N'COLUMN',@level2name=N'RoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام نقش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Roles', @level2type=N'COLUMN',@level2name=N'RoleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات نقش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Roles', @level2type=N'COLUMN',@level2name=N'RoleDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد مکان ورزشی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'SpaceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد سازمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'OrgId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد ساختمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'BuildingId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'والد مکان ورزشی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'ParentSpaceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام مکان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'SpaceName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع مکان (1: عمومی | 2: باشگاه | 3: سالن اجتماعات | 4: مغازه | 5: کلاس | 6: سالن ورزشی | 7: دفتر | 8: انبار | 9: پارکینگ | 10: سایر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'SpaceType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ظرفیت' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'Capacity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'مساحت' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'Area'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات مکان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'SpaceDesc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'قابل رزور(1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'IsReservable'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال است (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده؟ (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'مکان ورزشی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Spaces'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد واحد ساختمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'UnitId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد ساختمان' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'BuildingId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'شماره واحد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'UnitNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'طبقه واحد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'FloorNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'مساحت' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'Area'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تعداد خواب' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'Bedrooms'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات واحد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'UnitDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال است (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده؟ (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Units', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد اعتبارسنجی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'OtpRequestId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد کاربر' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'موبایل' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'Mobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'OtpCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع کد (1: Signup)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'OtpPurpose'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ انقضا' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'ExpiresAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ تایید' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'VerifiedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تعداد تلاش‌ها' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'AttemptCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حداکثر تعداد تلاش‌ها' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'MaxAttempts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'استفاده شده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'IsUsed'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'بلاک شده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'IsBlocked'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ای پی درخواست' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserOtpRequests', @level2type=N'COLUMN',@level2name=N'RequestIp'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد پروفایل کاربر' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'UserProfileId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد کاربر' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام پدر' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'FatherName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'محل تولد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'BirthPlace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تلفن' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'LandlinePhone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد پستی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'UserPostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ادرس' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'UserAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تلفن مواقع اضطراری' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'EmergencyContactName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تلفن مواقع اضطراری' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'EmergencyContactMobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'رابطه فرد مواقع اضطراری' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'EmergencyContactRelation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'Notes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserProfiles', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد کاربر واحد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'UserResidencyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد کاربر' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد واحد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'UnitId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نوع مالکیت (1: ساکن 2: مالک 3: خانواده مالک 4: نزدیکان مالک 5: خارج از ساختمان)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'RelationshipType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ شروع مالکیت' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'StartDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ پایان مالکیت' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال است (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده؟ (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'توضیحات' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'Notes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserResidencies', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد کاربر نقش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'UserRoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد کاربر' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد نقش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'RoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ تخصیص نقش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'AssignedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ انقضا' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'ExpiresAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال اسن (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده؟ (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRoles', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد کاربری' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام کاربر' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Username'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کلمه عبور کاربر' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'PasswordHash'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ایمیل' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'موبایل' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Mobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'نام خانوادگی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'LastName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کد ملی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'NationalId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'جنسیت (1: مرد 2: زن)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Gender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ تولد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'BirthDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عکس' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'AvatarUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تایید موبایل (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'PhoneVerified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'آخرین بازدید' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'LastLoginAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'فعال است (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'حذف شده؟ (1: بله 0: خیر)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ایجاد' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'CreatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ایجاد کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'UserCreater'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'تاریخ ویرایش' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'UpdatedAt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'کاربر ویرایش کننده' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'UserUpdater'
GO
