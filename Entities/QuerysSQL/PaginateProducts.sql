ALTER PROCEDURE [dbo].[paginated_products]
(
    @Page INT,
    @Reg INT,
    @Filter NVARCHAR(MAX) NULL = NULL,
    @FilterValue NVARCHAR(MAX) NULL = NULL,
    @PriceMin DECIMAL(18,2) NULL = NULL,
    @PriceMax DECIMAL(18,2) NULL = NULL,
    @Review DECIMAL(18,2) NULL = NULL,
    @CategoryIds NVARCHAR(MAX) NULL = NULL,
    @FeactureIds NVARCHAR(MAX) NULL = NULL,
    @StarTime DATETIME NULL = NULL,
    @EndTime DATETIME NULL = NULL,
	@Serving INT NULL = NULL,
    @SorterValue NVARCHAR(MAX),
    @Sort INT NULL
)
AS
BEGIN
    DECLARE @IgnoredReg INT = (@Page - 1) * @Reg;

    SELECT
        P.[ProductId],
        P.[Name] AS ProductName,
        P.[Description] AS ProductDescription,
        P.[Image] AS ProductImage,
        P.[TypeId],
        P.[Price],
        P.[Ingredients],
        P.[Active] AS ProductActive,
		P.[Review],
		P.[Serving],
		P.[Stock],
        P.[ApplicationUserId],
        US.[Name] AS UserName,
        US.[LastName] AS UserLastName,
		STRING_AGG(CASE WHEN CAT.[CategoryId] IS NOT NULL THEN CONCAT('{"CategoryId":',CAT.[CategoryId],',"Name":"',CAT.[Name],'","Active":',CAT.[Active],',"Image":"',ISNULL(CAT.[Image],'N/P'),'"}') ELSE '' END ,',') AS [Categories],
		STRING_AGG( CASE WHEN PF.[ProductFeatureId] IS NOT NULL THEN CONCAT('{"ProductFeatureId":',PF.[ProductFeatureId],',"Features":"',PF.[Features],'","MultipleSelection":',PF.[MultipleSelection],',"IsAdditional":',PF.IsAdditional,',"AdditionalValue":',PF.[AdditionalValue],',"ApplicationUserId":"',PF.[ApplicationUserId],'"}') ELSE '' END ,',') AS [ProductFeatures],
		 STRING_AGG(CASE WHEN PS.[ProductScheduleId] IS NOT NULL THEN CONCAT('{"StarTime":"', FORMAT(PS.[StarTime], 'yyyy-MM-ddTHH:mm:ss'), '","EndTime":"', FORMAT(PS.[EndTime], 'yyyy-MM-ddTHH:mm:ss'), '","PublicationStarTime":"', FORMAT(PS.[PublicationStarTime], 'yyyy-MM-ddTHH:mm:ss'), '","PublicationEndTime":"', FORMAT(PS.[PublicationEndTime], 'yyyy-MM-ddTHH:mm:ss'), '","Active":', CAST(PS.[Active] AS NVARCHAR(MAX)), ',"ProductId":', CAST(PS.[ProductId] AS NVARCHAR(MAX)), ',"ProductScheduleId":', CAST(PS.[ProductScheduleId] AS NVARCHAR(MAX)), '}' ) ELSE '' END, ',' ) AS [ProductSchedules]
    FROM
        dbo.Products AS P
    INNER JOIN
        [dbo].[AspNetUsers] AS US ON US.[Id] = P.[ApplicationUserId]
	INNER JOIN
        [dbo].[ProductSchedules] AS PS ON PS.[ProductId] = P.[ProductId]
	LEFT JOIN
		[dbo].[ProductFeaturesDetails] AS PFD ON PFD.[ProductId] = P.[ProductId]
	LEFT JOIN
		[dbo].[ProductFeatures] AS PF ON PF.[ProductFeatureId] = PFD.[ProductFeaturesId] 
	LEFT JOIN
		(SELECT Value AS [SPFeactureId] FROM STRING_SPLIT(@FeactureIds, ',')) AS PFFL 
		ON PFFL.[SPFeactureId] = PFD.[ProductFeaturesId] 

	LEFT JOIN
		[dbo].[ProductCategorys] AS PCAT ON PCAT.[ProductId] = P.[ProductId]
	LEFT JOIN
		[dbo].[Categories] AS CAT ON CAT.[CategoryId] = PCAT.[CategoryId]
	LEFT JOIN
		(SELECT Value AS [SPCategoryId] FROM STRING_SPLIT(@CategoryIds, ',')) AS CATFL 
		ON CATFL.[SPCategoryId] = PCAT.[CategoryId] 
    WHERE 
		 ([dbo].[ValidateFilter]
								(
									P.[ProductId],
									P.[Name],
									P.[Description],
									P.[Image],
									P.[TypeId],
									P.[Price],
									P.[Ingredients],
									P.[Active],
									P.[Review],
									P.[ApplicationUserId],
									US.[Name],
									US.[LastName],
									CATFL.[SPCategoryId],
									PFFL.[SPFeactureId],
									PS.[PublicationStarTime],
									PS.[PublicationEndTime],
									P.[Serving],
									@FilterValue,
									@PriceMin,
									@PriceMax,
									@Review,
									@StarTime,
									@EndTime,
									@Serving
								)) = 1
			AND P.[Stock] > 0
	GROUP BY P.[ProductId],
        P.[Name],
        P.[Description],
        P.[Image],
        P.[TypeId],
        P.[Price],
        P.[Ingredients],
        P.[Active],
		P.[Review],
        P.[ApplicationUserId],
        US.[Name],
        US.[LastName],
		P.[Serving],
		P.[Stock]
    ORDER BY
		CASE  WHEN @SorterValue = 'productId' AND @Sort = 0 THEN P.[ProductId] END ASC,
		CASE  WHEN @SorterValue = 'name' AND @Sort = 0 THEN P.[Name] END ASC,
		CASE  WHEN @SorterValue = 'description' AND @Sort = 0 THEN P.[Description] END ASC,
		CASE  WHEN @SorterValue = 'image' AND @Sort = 0 THEN P.[Image] END ASC,
		CASE  WHEN @SorterValue = 'typeId' AND @Sort = 0 THEN P.[TypeId] END ASC,
		CASE  WHEN @SorterValue = 'price' AND @Sort = 0 THEN P.[Price] END ASC,
		CASE  WHEN @SorterValue = 'ingredients' AND @Sort = 0 THEN P.[Ingredients] END ASC,
		CASE  WHEN @SorterValue = 'active' AND @Sort = 0 THEN P.[Active] END ASC,
		CASE  WHEN @SorterValue = 'review' AND @Sort = 0 THEN P.[Review] END ASC,
		CASE  WHEN @SorterValue = 'applicationUserId' AND @Sort = 0 THEN P.[ApplicationUserId] END ASC,
		CASE  WHEN @SorterValue = 'userName' AND @Sort = 0 THEN US.[Name] END ASC,
		CASE  WHEN @SorterValue = 'userLastName' AND @Sort = 0 THEN US.[LastName] END ASC
    OFFSET @IgnoredReg ROWS
    FETCH NEXT @Reg ROWS ONLY;

    SELECT
        COUNT(1) AS TotalRegistros
   FROM
        dbo.Products AS P
    INNER JOIN
        [dbo].[AspNetUsers] AS US ON US.[Id] = P.[ApplicationUserId]
	INNER JOIN
        [dbo].[ProductSchedules] AS PS ON PS.[ProductId] = P.[ProductId]
	LEFT JOIN
		[dbo].[ProductFeaturesDetails] AS PFD ON PFD.[ProductId] = P.[ProductId]
	LEFT JOIN
		[dbo].[ProductFeatures] AS PF ON PF.[ProductFeatureId] = PFD.[ProductFeaturesId] 
	LEFT JOIN
		(SELECT Value AS [SPFeactureId] FROM STRING_SPLIT(@FeactureIds, ',')) AS PFFL 
		ON PFFL.[SPFeactureId] = PFD.[ProductFeaturesId] 

	LEFT JOIN
		[dbo].[ProductCategorys] AS PCAT ON PCAT.[ProductId] = P.[ProductId]
	LEFT JOIN
		[dbo].[Categories] AS CAT ON CAT.[CategoryId] = PCAT.[CategoryId]
	LEFT JOIN
		(SELECT Value AS [SPCategoryId] FROM STRING_SPLIT(@CategoryIds, ',')) AS CATFL 
		ON CATFL.[SPCategoryId] = PCAT.[CategoryId] 
     WHERE 
		  ([dbo].[ValidateFilter]
								(
									P.[ProductId],
									P.[Name],
									P.[Description],
									P.[Image],
									P.[TypeId],
									P.[Price],
									P.[Ingredients],
									P.[Active],
									P.[Review],
									P.[ApplicationUserId],
									US.[Name],
									US.[LastName],
									CATFL.[SPCategoryId],
									PFFL.[SPFeactureId],
									PS.[PublicationStarTime],
									PS.[PublicationEndTime],
									P.[Serving],
									@FilterValue,
									@PriceMin,
									@PriceMax,
									@Review,
									@StarTime,
									@EndTime,
									@Serving
								)) = 1
			AND P.[Stock] > 0
	GROUP BY P.[ProductId],
        P.[Name],
        P.[Description],
        P.[Image],
        P.[TypeId],
        P.[Price],
        P.[Ingredients],
        P.[Active],
		P.[Review],
        P.[ApplicationUserId],
        US.[Name],
        US.[LastName],
		P.[Serving],
		P.[Stock];
END;
