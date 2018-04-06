
Public Class Audit

    Public Const Clubs As Integer = 1
    Public Const Teams As Integer = 2
    Public Const TeamsManagment As Integer = 3
    Public Const Players As Integer = 4
    Public Const ComptitionSchedule As Integer = 5
    Public Const Referee As Integer = 6
    Public Const Issuing As Integer = 7
    Public Const Incoming As Integer = 8
    Public Const KuwaitTeamManagment As Integer = 9
    Public Const KuwaitTeamPlayers As Integer = 10
    Public Const HeroismData As Integer = 11
    Public Const HeroismSchedule As Integer = 12
    Public Const Penalties As Integer = 13
    Public Const TrainingCourse As Integer = 14
    Public Const MasterFiles As Integer = 15
    Public Const KuwaitTeamData As Integer = 16
    Public Const Permissions As Integer = 17

    

    Public Shared Function InsertAudit(ByVal AuditTypeCode As Integer, _
                                       ByVal AuditSection As Integer, _
                                       ByVal AuditDate As DateTime, _
                                       ByVal UserCode As Integer, _
                                       ByVal Description As String) As Boolean
        Try
            Dim Para As New ArrayList

            Para.Add(AuditTypeCode)
            Para.Add(AuditSection)
            Para.Add(AuditDate)
            Para.Add(UserCode)
            Para.Add(Description)

            Return DBO.ExecuteSP("A_AuditInsert", Para)

        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function
    Public Shared Function InsertAudit(ByVal AuditSection As Integer, ByVal AuditTypeCode As Integer, ByVal Description As String) As Boolean
        Try
            InsertAudit(AuditTypeCode, AuditSection, Now, UserClass.Code, Description)
        Catch ex As Exception
            MSG.ErrorOk(ex.Message)
        End Try
    End Function

    'Loggin
    Public Shared Function LogIn() As Boolean
        InsertAudit(9, 7, "Log In")
    End Function
    Public Shared Function LogOut() As Boolean
        InsertAudit(9, 8, "Log Out")
    End Function


    ''Clubs 
    'Public Shared Function AddClubs(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(1, 1, "إضافة  بيانات نادى  :" & Desciption)
    'End Function
    'Public Shared Function DeleteClubs(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(1, 2, "حذف بيانات نادى" & Desciption)
    'End Function
    'Public Shared Function EditClubs(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(1, 3, "تعديل نادى" & Desciption)
    'End Function
    'Public Shared Function ViewClubs(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(1, 4, "عرض نادى :" & Desciption)
    'End Function
    'Public Shared Function SearchClubs(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(1, 5, "بحث نادى :" & Desciption)
    'End Function
    'Public Shared Function PrintClubs(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(1, 6, "طباعة بيانات نادى :" & Desciption)
    'End Function
    'Public Shared Function ExportClubs(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(1, 9, "تصدير بيانات نادى :" & Desciption)
    'End Function

    ''Teams 
    'Public Shared Function AddTeams(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(2, 1, "إضافة بيانات فريق :" & Desciption)
    'End Function
    'Public Shared Function DeleteTeams(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(2, 2, "حذف بيانات فرق :" & Desciption)
    'End Function
    'Public Shared Function EditTeams(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(2, 3, "تعديل بيانات فريق :" & Desciption)
    'End Function
    'Public Shared Function ViewTeams(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(2, 4, "عرض بيانات فريق :" & Desciption)
    'End Function
    'Public Shared Function SearchTeams(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(2, 5, "بحث بيانات فريق :" & Desciption)
    'End Function
    'Public Shared Function PrintTeams(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(2, 6, "طباعة بيانات فريق :" & Desciption)
    'End Function
    'Public Shared Function ExportTeams(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(2, 9, "تصدير بيانات فريق :" & Desciption)
    'End Function

    ''TeamsManagment
    'Public Shared Function AddTeamsManagment(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(3, 1, "إضافة  اداريين فريق :" & Desciption)
    'End Function
    'Public Shared Function DeleteTeamsManagment(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(3, 2, "حذف اداريين فريق :" & Desciption)
    'End Function
    'Public Shared Function EditTeamsManagment(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(3, 3, "تعديل اداريين فريق :" & Desciption)
    'End Function
    'Public Shared Function ViewTeamsManagment(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(3, 4, "عرض اداريين فريق :" & Desciption)
    'End Function
    'Public Shared Function SearchTeamsManagment(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(3, 5, "بحث ادارييين فريق :" & Desciption)
    'End Function
    'Public Shared Function PrintTeamsManagment(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(3, 6, "طباعة اداريين فريق :" & Desciption)
    'End Function
    'Public Shared Function ExportTeamsManagment(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(3, 9, "تصدير اداريين فريق :" & Desciption)
    'End Function

    ''Players 
    'Public Shared Function AddPlayers(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(4, 1, "إضافة  بيانات لاعب :" & Desciption)
    'End Function
    'Public Shared Function DeletePlayers(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(4, 2, "حذف بيانات لاعب :" & Desciption)
    'End Function
    'Public Shared Function EditPlayers(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(4, 3, "تعديل بيانات لاعب :" & Desciption)
    'End Function
    'Public Shared Function ViewPlayers(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(4, 4, "عرض بيانات لاعب :" & Desciption)
    'End Function
    'Public Shared Function SearchPlayers(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(4, 5, "بحث بيانات لاعب :" & Desciption)
    'End Function
    'Public Shared Function PrintPlayers(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(4, 6, "طباعة بيانات لاعب :" & Desciption)
    'End Function
    'Public Shared Function ExportPlayers(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(4, 9, "تصدير بيانات لاعب :" & Desciption)
    'End Function

    ''ComptitionSchedule 
    'Public Shared Function AddComptitionSchedule(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(5, 1, "إضافة  فى جدول المسابقات :" & Desciption)
    'End Function
    'Public Shared Function DeleteComptitionSchedule(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(5, 2, "حذف بجدول المسابقات :" & Desciption)
    'End Function
    'Public Shared Function EditComptitionSchedule(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(5, 3, "تعديل جدول المسابقات :" & Desciption)
    'End Function
    'Public Shared Function ViewComptitionSchedule(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(5, 4, "عرض جدول المسابقات :" & Desciption)
    'End Function
    'Public Shared Function SearchComptitionSchedule(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(5, 5, "بحث بجدول المسابقات :" & Desciption)
    'End Function
    'Public Shared Function PrintComptitionSchedule(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(5, 6, "طباعة جدول المسابقات :" & Desciption)
    'End Function
    'Public Shared Function ExportComptitionSchedule(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(5, 9, "تصدير جدول المسابقات :" & Desciption)
    'End Function

    ''Referee 
    'Public Shared Function AddReferee(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(7, 1, "إضافة  الحكام :" & Desciption)
    'End Function
    'Public Shared Function DeleteReferee(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(7, 2, "حذف حكم :" & Desciption)
    'End Function
    'Public Shared Function EditReferee(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(7, 3, "تعديل حكم :" & Desciption)
    'End Function
    'Public Shared Function ViewReferee(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(7, 4, "عرض حكم :" & Desciption)
    'End Function
    'Public Shared Function SearchReferee(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(7, 5, "بحث حكم :" & Desciption)
    'End Function
    'Public Shared Function PrintReferee(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(7, 6, "طباعة بيانات حكم :" & Desciption)
    'End Function
    'Public Shared Function ExportReferee(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(7, 9, "تصدير بيانات حكم :" & Desciption)
    'End Function

    ''Issuing
    'Public Shared Function AddIssuing(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(6, 1, "إضافة  بيانات صادر :" & Desciption)
    'End Function
    'Public Shared Function DeleteIssuing(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(6, 2, "حذف بيانات صادر :" & Desciption)
    'End Function
    'Public Shared Function EditIssuing(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(6, 3, "تعديل بيانات صادر :" & Desciption)
    'End Function
    'Public Shared Function ViewIssuing(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(6, 4, "عرض بيانات صادر :" & Desciption)
    'End Function
    'Public Shared Function SearchIssuing(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(6, 5, "بحث بيانات صادر :" & Desciption)
    'End Function
    'Public Shared Function PrintIssuing(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(6, 6, "طباعة بيانات صادر :" & Desciption)
    'End Function
    'Public Shared Function ExportIssuing(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(6, 9, "تصدير بيانات صادر :" & Desciption)
    'End Function

    ''Incoming 
    'Public Shared Function AddIncoming(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(8, 1, "إضافة  بيانات وارد :" & Desciption)
    'End Function
    'Public Shared Function DeleteIncoming(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(8, 2, "حذف بيانات وادر :" & Desciption)
    'End Function
    'Public Shared Function EditIncoming(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(8, 3, "تعديل بيانات وارد :" & Desciption)
    'End Function
    'Public Shared Function ViewIncoming(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(8, 4, "عرض بيانات وارد :" & Desciption)
    'End Function
    'Public Shared Function SearchIncoming(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(8, 5, "بحث بيانات وارد :" & Desciption)
    'End Function
    'Public Shared Function PrintIncoming(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(8, 6, "طباعة بيانات وارد :" & Desciption)
    'End Function
    'Public Shared Function ExportIncoming(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(8, 9, "تصدير بيانات وارد :" & Desciption)
    'End Function

    ''KuwaitTeamManagment
    'Public Shared Function AddKuwaitTeamManagment(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(10, 1, "إضافة  اداريين المنتخب :" & Desciption)
    'End Function
    'Public Shared Function DeleteKuwaitTeamManagment(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(10, 2, "حذف اداريين المنتخب :" & Desciption)
    'End Function
    'Public Shared Function EditKuwaitTeamManagment(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(10, 3, "تعديل اداريين المنتخب :" & Desciption)
    'End Function
    'Public Shared Function ViewKuwaitTeamManagment(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(10, 4, "عرض اداريين المنتخب :" & Desciption)
    'End Function
    'Public Shared Function SearchKuwaitTeamManagment(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(10, 5, "بحث عن اداريين المنتخب :" & Desciption)
    'End Function
    'Public Shared Function PrintKuwaitTeamManagment(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(10, 6, "طباعة بيانات اداريين المنتخب :" & Desciption)
    'End Function
    'Public Shared Function ExportKuwaitTeamManagment(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(10, 9, "تصدير بيانات اداريين المنتخب :" & Desciption)
    'End Function

    ''KuwaitTeamPlayers
    'Public Shared Function AddKuwaitTeamPlayers(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(11, 1, "إضافة  بيانات لاعبى المنتخب :" & Desciption)
    'End Function
    'Public Shared Function DeleteKuwaitTeamPlayers(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(11, 2, "حذف بيانات لاعبى المنتخب :" & Desciption)
    'End Function
    'Public Shared Function EditKuwaitTeamPlayers(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(11, 3, "تعديل بيانات لاعبى المنتخب :" & Desciption)
    'End Function
    'Public Shared Function ViewKuwaitTeamPlayers(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(11, 4, "عرض لاعبى المنتخب :" & Desciption)
    'End Function
    'Public Shared Function SearchKuwaitTeamPlayers(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(11, 5, "بحث لاعبى المنتخب :" & Desciption)
    'End Function
    'Public Shared Function PrintKuwaitTeamPlayers(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(11, 6, "طباعة لاعبى المنتخب :" & Desciption)
    'End Function
    'Public Shared Function ExportKuwaitTeamPlayers(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(11, 9, "تصدير بيانات المنتخب :" & Desciption)
    'End Function

    ''HeroismData 
    'Public Shared Function AddHeroismData(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(12, 1, "إضافة  بيانات بطولات :" & Desciption)
    'End Function
    'Public Shared Function DeleteHeroismData(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(12, 2, "حذف بيانات البطولات :" & Desciption)
    'End Function
    'Public Shared Function EditHeroismData(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(12, 3, "تعديل بيانات البطولات :" & Desciption)
    'End Function
    'Public Shared Function ViewHeroismData(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(12, 4, "عرض بيانات البطولات :" & Desciption)
    'End Function
    'Public Shared Function SearchHeroismData(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(12, 5, "بحث بيانات البطولات :" & Desciption)
    'End Function
    'Public Shared Function PrintHeroismData(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(12, 6, "طباعة بيانات البطولات :" & Desciption)
    'End Function
    'Public Shared Function ExportHeroismData(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(12, 9, "تصدير بيانات البطولات :" & Desciption)
    'End Function

    ''HeroismSchedule 
    'Public Shared Function AddHeroismSchedule(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(13, 1, "إضافة  جدول بطولات :" & Desciption)
    'End Function
    'Public Shared Function DeleteHeroismSchedule(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(13, 2, "حذف جدول بطولات :" & Desciption)
    'End Function
    'Public Shared Function EditHeroismSchedule(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(13, 3, "تعديل بيانات جدول بطولات :" & Desciption)
    'End Function
    'Public Shared Function ViewHeroismSchedule(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(13, 4, "عرض جدول بطولات :" & Desciption)
    'End Function
    'Public Shared Function SearchHeroismSchedule(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(13, 5, "بحث عن جدول بطولات :" & Desciption)
    'End Function
    'Public Shared Function PrintHeroismSchedule(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(13, 6, "طباعة جدول بطولات :" & Desciption)
    'End Function
    'Public Shared Function ExportHeroismSchedule(Optional ByVal Desciption As String = "") As Boolean
    '    Return InsertAudit(13, 9, "تصدير بيانات بطولات :" & Desciption)
    'End Function

    ''Penalties 
    'Public Shared Function AddPenalties(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(14, 1, "إضافة  عقوبات :" & Desciption)
    'End Function
    'Public Shared Function DeletePenalties(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(14, 2, "حذف عقوبات :" & Desciption)
    'End Function
    'Public Shared Function EditPenalties(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(14, 3, "تعديل عقوبات :" & Desciption)
    'End Function
    'Public Shared Function ViewPenalties(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(14, 4, "عرض عقوبات :" & Desciption)
    'End Function
    'Public Shared Function SearchPenalties(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(14, 5, "بحث عن عقوبات :" & Desciption)
    'End Function
    'Public Shared Function PrintPenalties(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(14, 6, "طباعة عقوبات :" & Desciption)
    'End Function
    'Public Shared Function ExportPenalties(Optional ByVal Desciption As String = "") As Boolean
    '    Return InsertAudit(14, 9, "تصدير بيان عقوبات :" & Desciption)
    'End Function

    ''TrainingCourse 
    'Public Shared Function AddTrainingCourse(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(15, 1, "إضافة  دورات تدريبية :" & Desciption)
    'End Function
    'Public Shared Function DeleteTrainingCourse(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(15, 2, "حذف دورات تدريبية :" & Desciption)
    'End Function
    'Public Shared Function EditTrainingCourse(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(15, 3, "تعديل دورة تدريبية :" & Desciption)
    'End Function
    'Public Shared Function ViewTrainingCourse(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(15, 4, "عرض دورة تدريبية :" & Desciption)
    'End Function
    'Public Shared Function SearchTrainingCourse(Optional ByVal Desciption As String = "") As Boolean
    '    InsertAudit(15, 5, "بحث عن دورة تدريبية :" & Desciption)
    'End Function
    'Public Shared Function PrintTrainingCourse(Optional ByVal Desciption As String = "") As Boolean
    '    Return InsertAudit(15, 6, "طباعة بيانات دورة تدريبية :" & Desciption)
    'End Function
    'Public Shared Function ExportTrainingCourse(Optional ByVal Desciption As String = "") As Boolean
    '    Return InsertAudit(15, 9, "تصدير بيانات دورة تدريبية :" & Desciption)
    'End Function

    ''MasterFiles 
    'Public Shared Function AddMasterFiles(Optional ByVal Desciption As String = "") As Boolean
    '    Return InsertAudit(16, 1, "إضافة بيانات اساسية :" & Desciption)
    'End Function
    'Public Shared Function DeleteMasterFiles(Optional ByVal Desciption As String = "") As Boolean
    '    Return InsertAudit(16, 2, "حذف بيانات اساسية :" & Desciption)
    'End Function
    'Public Shared Function EditMasterFiles(Optional ByVal Desciption As String = "") As Boolean
    '    Return InsertAudit(16, 3, "تعديل بيانات اساسية :" & Desciption)
    'End Function
    'Public Shared Function ViewMasterFiles(Optional ByVal Desciption As String = "") As Boolean
    '    Return InsertAudit(16, 4, "عرض بيانات اساسية :" & Desciption)
    'End Function
    'Public Shared Function SearchMasterFiles(Optional ByVal Desciption As String = "") As Boolean
    '    Return InsertAudit(16, 5, "بحث عن بيانات اساسية :" & Desciption)
    'End Function
    'Public Shared Function PrintMasterFiles(Optional ByVal Desciption As String = "") As Boolean
    '    Return InsertAudit(16, 6, "طباعة بيانات اساسية :" & Desciption)
    'End Function
    'Public Shared Function ExportMasterFiles(Optional ByVal Desciption As String = "") As Boolean
    '    Return InsertAudit(16, 9, "تصدير بيانات اساسية :" & Desciption)
    'End Function
    ''KuwaitTeamData 
    'Public Shared Function AddKuwaitTeamData(Optional ByVal Desciption As String = "") As Boolean
    '    Return InsertAudit(16, 1, "إضافة بيانات المنتخب الوطنى :" & Desciption)
    'End Function
    'Public Shared Function DeleteKuwaitTeamData(Optional ByVal Desciption As String = "") As Boolean
    '    Return InsertAudit(16, 2, "حذف بيانات المنتخب الوطنى :" & Desciption)
    'End Function
    'Public Shared Function EditKuwaitTeamData(Optional ByVal Desciption As String = "") As Boolean
    '    Return InsertAudit(16, 3, "تعديل بيانات المنتخب الوطنى :" & Desciption)
    'End Function
    'Public Shared Function ViewKuwaitTeamData(Optional ByVal Desciption As String = "") As Boolean
    '    Return InsertAudit(16, 4, "عرض بيانات المنتخب الوطنى :" & Desciption)
    'End Function
    'Public Shared Function SearchKuwaitTeamData(Optional ByVal Desciption As String = "") As Boolean
    '    Return InsertAudit(16, 5, "بحث عن بيانات منتخب وطنى :" & Desciption)
    'End Function
    'Public Shared Function PrintKuwaitTeamData(Optional ByVal Desciption As String = "") As Boolean
    '    Return InsertAudit(16, 6, "طباعة بيانات المنتخب الوطنى :" & Desciption)
    'End Function
    'Public Shared Function ExportKuwaitTeamData(Optional ByVal Desciption As String = "") As Boolean
    '    Return InsertAudit(16, 9, "تصدير بيانات المنتخب الوطنى :" & Desciption)
    'End Function
    ''Permissions
    'Public Shared Function AddPermissions(Optional ByVal Desciption As String = "") As Boolean
    '    Return InsertAudit(16, 1, "إضافة بيانات صلاحسات مستخدمين :" & Desciption)
    'End Function
    'Public Shared Function DeletePermissions(Optional ByVal Desciption As String = "") As Boolean
    '    Return InsertAudit(16, 2, "حذف صلاحيات مستخدمين :" & Desciption)
    'End Function
    'Public Shared Function EditPermissions(Optional ByVal Desciption As String = "") As Boolean
    '    Return InsertAudit(16, 3, "تعديل صلاحيات مستخدمين :" & Desciption)
    'End Function
    'Public Shared Function ViewPermissions(Optional ByVal Desciption As String = "") As Boolean
    '    Return InsertAudit(16, 4, "عرض صلاحيات مستخدمين :" & Desciption)
    'End Function
    'Public Shared Function SearchPermissions(Optional ByVal Desciption As String = "") As Boolean
    '    Return InsertAudit(16, 5, "بحث عن مستخدمين :" & Desciption)
    'End Function
    'Public Shared Function PrintPermissions(Optional ByVal Desciption As String = "") As Boolean
    '    Return InsertAudit(16, 6, "طباعة بيانات مستخدمين :" & Desciption)
    'End Function
    'Public Shared Function ExportPermissions(Optional ByVal Desciption As String = "") As Boolean
    '    Return InsertAudit(16, 9, "تصدير بيانات صلاحيات مستخدمين :" & Desciption)
    'End Function





    ''Usage

    ''Clubs 
    ''Teams 
    ''TeamsManagment
    ''Players 
    ''ComptitionSchedule 
    ''Referee 
    ''Issuing
    ''Incoming 
    ''KuwaitTeamManagment
    ''KuwaitTeamPlayers
    ''HeroismData 
    ''HeroismSchedule 
    ''Penalties 
    ''TrainingCourse 
    ''MasterFiles 
    ''KuwaitTeamData 
    ''Permissions 

    'Public Shared Function AuditAdd(ByVal AuditSection As Integer, Optional ByVal Description As String = "") As Boolean
    '    Select Case AuditSection
    '        Case Clubs
    '            AddClubs(Description)
    '        Case Teams
    '            AddTeams(Description)
    '        Case TeamsManagment
    '            AddTeamsManagment(Description)
    '        Case Players
    '            AddPlayers(Description)
    '        Case ComptitionSchedule
    '            AddComptitionSchedule(Description)
    '        Case Referee
    '            AddIssuing(Description)
    '        Case Issuing
    '            AddReferee(Description)
    '        Case Incoming
    '            AddIncoming(Description)
    '        Case KuwaitTeamManagment
    '            AddKuwaitTeamManagment(Description)
    '        Case KuwaitTeamPlayers
    '            AddKuwaitTeamPlayers(Description)
    '        Case HeroismData
    '            AddHeroismData(Description)
    '        Case HeroismSchedule
    '            AddHeroismSchedule(Description)
    '        Case Penalties
    '            AddPenalties(Description)
    '        Case TrainingCourse
    '            AddTrainingCourse(Description)
    '        Case MasterFiles
    '            AddMasterFiles(Description)
    '        Case KuwaitTeamData
    '            AddKuwaitTeamData(Description)
    '        Case Permissions
    '            AddPermissions(Description)
    '    End Select
    'End Function
    'Public Shared Function AuditDelete(ByVal AuditSection As Integer, Optional ByVal Description As String = "") As Boolean
    '    Select Case AuditSection
    '        Case Clubs
    '            DeleteClubs(Description)
    '        Case Teams
    '            DeleteTeams(Description)
    '        Case TeamsManagment
    '            DeleteTeamsManagment(Description)
    '        Case Players
    '            DeletePlayers(Description)
    '        Case ComptitionSchedule
    '            DeleteComptitionSchedule(Description)
    '        Case Referee
    '            DeleteIssuing(Description)
    '        Case Issuing
    '            DeleteReferee(Description)
    '        Case Incoming
    '            DeleteIncoming(Description)
    '        Case KuwaitTeamManagment
    '            DeleteKuwaitTeamManagment(Description)
    '        Case KuwaitTeamPlayers
    '            DeleteKuwaitTeamPlayers(Description)
    '        Case HeroismData
    '            DeleteHeroismData(Description)
    '        Case HeroismSchedule
    '            DeleteHeroismSchedule(Description)
    '        Case Penalties
    '            DeletePenalties(Description)
    '        Case TrainingCourse
    '            DeleteTrainingCourse(Description)
    '        Case MasterFiles
    '            DeleteMasterFiles(Description)
    '        Case KuwaitTeamData
    '            DeleteKuwaitTeamData(Description)
    '        Case Permissions
    '            DeletePermissions(Description)
    '    End Select
    'End Function
    'Public Shared Function AuditView(ByVal AuditSection As Integer, Optional ByVal Description As String = "") As Boolean
    '    Select Case AuditSection
    '        Case Clubs
    '            ViewClubs(Description)
    '        Case Teams
    '            ViewTeams(Description)
    '        Case TeamsManagment
    '            ViewTeamsManagment(Description)
    '        Case Players
    '            ViewPlayers(Description)
    '        Case ComptitionSchedule
    '            ViewComptitionSchedule(Description)
    '        Case Referee
    '            ViewIssuing(Description)
    '        Case Issuing
    '            ViewReferee(Description)
    '        Case Incoming
    '            ViewIncoming(Description)
    '        Case KuwaitTeamManagment
    '            ViewKuwaitTeamManagment(Description)
    '        Case KuwaitTeamPlayers
    '            ViewKuwaitTeamPlayers(Description)
    '        Case HeroismData
    '            ViewHeroismData(Description)
    '        Case HeroismSchedule
    '            ViewHeroismSchedule(Description)
    '        Case Penalties
    '            ViewPenalties(Description)
    '        Case TrainingCourse
    '            ViewTrainingCourse(Description)
    '        Case MasterFiles
    '            ViewMasterFiles(Description)
    '        Case KuwaitTeamData
    '            ViewKuwaitTeamData(Description)
    '        Case Permissions
    '            ViewPermissions(Description)
    '    End Select
    'End Function
    'Public Shared Function AuditEdit(ByVal AuditSection As Integer, Optional ByVal Description As String = "") As Boolean
    '    Select Case AuditSection
    '        Case Clubs
    '            EditClubs(Description)
    '        Case Teams
    '            EditTeams(Description)
    '        Case TeamsManagment
    '            EditTeamsManagment(Description)
    '        Case Players
    '            EditPlayers(Description)
    '        Case ComptitionSchedule
    '            EditComptitionSchedule(Description)
    '        Case Referee
    '            EditIssuing(Description)
    '        Case Issuing
    '            EditReferee(Description)
    '        Case Incoming
    '            EditIncoming(Description)
    '        Case KuwaitTeamManagment
    '            EditKuwaitTeamManagment(Description)
    '        Case KuwaitTeamPlayers
    '            EditKuwaitTeamPlayers(Description)
    '        Case HeroismData
    '            EditHeroismData(Description)
    '        Case HeroismSchedule
    '            EditHeroismSchedule(Description)
    '        Case Penalties
    '            EditPenalties(Description)
    '        Case TrainingCourse
    '            EditTrainingCourse(Description)
    '        Case MasterFiles
    '            EditMasterFiles(Description)
    '        Case KuwaitTeamData
    '            EditKuwaitTeamData(Description)
    '        Case Permissions
    '            EditPermissions(Description)
    '    End Select
    'End Function
    'Public Shared Function AuditSearch(ByVal AuditSection As Integer, Optional ByVal Description As String = "") As Boolean
    '    Select Case AuditSection
    '        Case Clubs
    '            SearchClubs(Description)
    '        Case Teams
    '            SearchTeams(Description)
    '        Case TeamsManagment
    '            SearchTeamsManagment(Description)
    '        Case Players
    '            SearchPlayers(Description)
    '        Case ComptitionSchedule
    '            SearchIssuing(Description)
    '        Case Referee
    '            SearchReferee(Description)
    '        Case Issuing
    '            SearchIncoming(Description)
    '        Case Incoming
    '            SearchKuwaitTeamManagment(Description)
    '        Case KuwaitTeamManagment
    '            SearchKuwaitTeamPlayers(Description)
    '        Case KuwaitTeamPlayers
    '            SearchHeroismData(Description)
    '        Case HeroismData
    '            SearchHeroismSchedule(Description)
    '        Case HeroismSchedule
    '            SearchPenalties(Description)
    '        Case Penalties
    '            SearchPenalties(Description)
    '        Case TrainingCourse
    '            SearchTrainingCourse(Description)
    '        Case MasterFiles
    '            SearchMasterFiles(Description)
    '        Case KuwaitTeamData
    '            SearchKuwaitTeamData(Description)
    '        Case Permissions
    '            SearchPermissions(Description)
    '    End Select
    'End Function
    'Public Shared Function AuditPrint(ByVal AuditSection As Integer, Optional ByVal Description As String = "") As Boolean
    '    Select Case AuditSection
    '        Case Clubs
    '            PrintClubs(Description)
    '        Case Teams
    '            PrintTeams(Description)
    '        Case TeamsManagment
    '            PrintTeamsManagment(Description)
    '        Case Players
    '            PrintPlayers(Description)
    '        Case ComptitionSchedule
    '            PrintComptitionSchedule(Description)
    '        Case Referee
    '            PrintIssuing(Description)
    '        Case Issuing
    '            PrintReferee(Description)
    '        Case Incoming
    '            PrintIncoming(Description)
    '        Case KuwaitTeamManagment
    '            PrintKuwaitTeamManagment(Description)
    '        Case KuwaitTeamPlayers
    '            PrintKuwaitTeamPlayers(Description)
    '        Case HeroismData
    '            PrintHeroismData(Description)
    '        Case HeroismSchedule
    '            PrintHeroismSchedule(Description)
    '        Case Penalties
    '            PrintPenalties(Description)
    '        Case TrainingCourse
    '            PrintTrainingCourse(Description)
    '        Case MasterFiles
    '            PrintMasterFiles(Description)
    '        Case KuwaitTeamData
    '            PrintKuwaitTeamData(Description)
    '        Case Permissions
    '            PrintPermissions(Description)
    '    End Select
    'End Function
    'Public Shared Function AuditExport(ByVal AuditSection As Integer, Optional ByVal Description As String = "") As Boolean
    '    Select Case AuditSection
    '        Case Clubs
    '            ExportClubs(Description)
    '        Case Teams
    '            ExportTeams(Description)
    '        Case TeamsManagment
    '            ExportTeamsManagment(Description)
    '        Case Players
    '            ExportPlayers(Description)
    '        Case ComptitionSchedule
    '            ExportComptitionSchedule(Description)
    '        Case Referee
    '            ExportIssuing(Description)
    '        Case Issuing
    '            ExportReferee(Description)
    '        Case Incoming
    '            ExportIncoming(Description)
    '        Case KuwaitTeamManagment
    '            ExportKuwaitTeamManagment(Description)
    '        Case KuwaitTeamPlayers
    '            ExportKuwaitTeamPlayers(Description)
    '        Case HeroismData
    '            ExportHeroismData(Description)
    '        Case HeroismSchedule
    '            ExportHeroismSchedule(Description)
    '        Case Penalties
    '            ExportPenalties(Description)
    '        Case TrainingCourse
    '            ExportTrainingCourse(Description)
    '        Case MasterFiles
    '            ExportMasterFiles(Description)
    '        Case KuwaitTeamData
    '            ExportKuwaitTeamData(Description)
    '        Case Permissions
    '            ExportPermissions(Description)
    '    End Select

    'End Function

End Class