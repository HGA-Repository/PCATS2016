create PROCEDURE [dbo].[spLogOff_Test_Global]
@ID		int	

as

update
	DT_UserLoginInfo

	set [Log_In_Off] = 0,
	[LogOFFTime] = Getdate()


where ID =  @ID



