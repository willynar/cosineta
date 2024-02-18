USE [trabajo]
GO
/****** Object:  StoredProcedure [dbo].[paginated_products]    Script Date: 18/02/2024 5:18:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[paginated_products]
(
    @Page INT,
    @Reg INT,
    @Filter NVARCHAR(MAX) NULL = NULL,
    @FilterValue NVARCHAR(MAX) NULL = NULL,
    @PriceMin DECIMAL(18,2) NULL = NULL,
    @PriceMax DECIMAL(18,2) NULL = NULL,
    @Review DECIMAL(18,2) NULL = NULL,
    @CategoryValue NVARCHAR(MAX) NULL = NULL,
    @SorterValue NVARCHAR(MAX),
    @Sort INT
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
        P.[ApplicationUserId],
        US.[Name] AS UserName,
        US.[LastName] AS UserLastName,
		STRING_AGG(CONCAT('{"CategoryId":',CAT.[CategoryId],',"Name":"',CAT.[Name],'","Active":',CAT.[Active],',"Image":"',ISNULL(CAT.[Image],'N/P'),'"}'),',') AS [Categories],
		STRING_AGG(CONCAT('{"ProductFeaturesDetailId":',PF.[ProductFeatureId],',"Features":"',PF.[Features],'","MultipleSelection":',PF.[MultipleSelection],',"IsAdditional":',PF.IsAdditional,',"AdditionalValue":',PF.[AdditionalValue],',"ApplicationUserId":"',PF.[ApplicationUserId],'"}'),',') AS [ProductFeatures]
    FROM
        dbo.Products AS P
    INNER JOIN
        [dbo].[AspNetUsers] AS US ON US.[Id] = P.[ApplicationUserId]
	LEFT JOIN
		[dbo].[ProductFeaturesDetails] AS PFD ON PFD.[ProductId] = P.[ProductId]
	LEFT JOIN
		[dbo].[ProductFeatures] AS PF ON PF.[ProductFeatureId] = PFD.[ProductFeaturesId] 
	LEFT JOIN
		[dbo].[ProductCategorys] AS PCAT ON PCAT.[ProductId] = P.[ProductId]
	LEFT JOIN
		[dbo].[Categories] AS CAT ON CAT.[CategoryId] = PCAT.[CategoryId]
    WHERE 
		 (CASE
				WHEN @Filter = 'PriceRange' THEN CASE WHEN (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) THEN 1 ELSE 0 END

				--WHEN @Filter = 'Category' THEN CASE WHEN EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') THEN 1 ELSE 0 END

				WHEN @Filter = 'Review' THEN CASE WHEN P.[Review] >= @Review THEN 1 ELSE 0 END

				--WHEN @Filter = 'FilterValue' THEN CASE WHEN (dbo.ValidateFilterValue(P.[ProductId],P.[Name],P.[Description],P.[Image],P.[TypeId],P.[Price],P.[Ingredients],P.[Active],P.[Review],P.[ApplicationUserId],US.[Name],US.[LastName],
				--	STRING_AGG(CAT.[Name],','),
				--	STRING_AGG(PF.[Features],','),@FilterValue) = 1) THEN 1 ELSE 0 END

				--WHEN @Filter = 'PriceRange,Category' THEN CASE WHEN (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') THEN 1 ELSE 0 END

				--WHEN @Filter = 'Review,Category' THEN CASE WHEN EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') AND P.[Review] >= @Review THEN 1 ELSE 0 END

				WHEN @Filter = 'PriceRange,Review' THEN CASE WHEN (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND P.[Review] >= @Review THEN 1 ELSE 0 END

				--WHEN @Filter = 'PriceRange,FilterValue' THEN CASE WHEN (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND (dbo.ValidateFilterValue(P.[ProductId],P.[Name],P.[Description],P.[Image],P.[TypeId],P.[Price],P.[Ingredients],P.[Active],P.[Review],P.[ApplicationUserId],US.[Name],US.[LastName],
				--	STRING_AGG(CAT.[Name],','),
				--	STRING_AGG(PF.[Features],','),@FilterValue) = 1) THEN 1 ELSE 0 END
				--WHEN @Filter = 'Category,FilterValue' THEN CASE WHEN EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') AND (dbo.ValidateFilterValue(P.[ProductId],P.[Name],P.[Description],P.[Image],P.[TypeId],P.[Price],P.[Ingredients],P.[Active],P.[Review],P.[ApplicationUserId],US.[Name],US.[LastName],
					--STRING_AGG(CAT.[Name],','),
					--STRING_AGG(PF.[Features],','),@FilterValue) = 1) THEN 1 ELSE 0 END

				--WHEN @Filter = 'Review,FilterValue' THEN CASE WHEN P.[Review] >= @Review AND (dbo.ValidateFilterValue(P.[ProductId],P.[Name],P.[Description],P.[Image],P.[TypeId],P.[Price],P.[Ingredients],P.[Active],P.[Review],P.[ApplicationUserId],US.[Name],US.[LastName],
				--	STRING_AGG(CAT.[Name],','),
				--	STRING_AGG(PF.[Features],','),@FilterValue) = 1) THEN 1 ELSE 0 END

				--WHEN @Filter = 'PriceRange,Category,Review' THEN CASE WHEN P.[Review] >= @Review AND (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') THEN 1 ELSE 0 END

				--WHEN @Filter = 'PriceRange,Category,FilterValue' THEN CASE WHEN P.[Review] >= @Review AND (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') THEN 1 ELSE 0 END

				WHEN @Filter = 'PriceRange,Review,FilterValue' THEN CASE WHEN P.[Review] >= @Review AND (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') THEN 1 ELSE 0 END

				--WHEN @Filter = 'Category,Review,FilterValue' THEN CASE WHEN P.[Review] >= @Review AND (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') THEN 1 ELSE 0 END

				WHEN @Filter = 'All' THEN CASE WHEN (
				--dbo.ValidateFilterValue(P.[ProductId],P.[Name],P.[Description],P.[Image],P.[TypeId],P.[Price],P.[Ingredients],P.[Active],P.[Review],P.[ApplicationUserId],US.[Name],US.[LastName],
				--	STRING_AGG(CAT.[Name],','),
				--	STRING_AGG(PF.[Features],','),@FilterValue) = 1)	AND 
					(P.[Price] >= @PriceMin AND P.[Price] <= @PriceMax)
					--AND EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%')
					AND P.[Review] >= @Review)
								THEN 1 ELSE 0 END
				ELSE	1
			END
		) = 1
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
        US.[LastName]
    ORDER BY
		CASE  WHEN @SorterValue = 'ProductId' AND @Sort = 0 THEN P.[ProductId] END ASC,
		CASE  WHEN @SorterValue = 'Name' AND @Sort = 0 THEN P.[Name] END ASC,
		CASE  WHEN @SorterValue = 'Description' AND @Sort = 0 THEN P.[Description] END ASC,
		CASE  WHEN @SorterValue = 'Image' AND @Sort = 0 THEN P.[Image] END ASC,
		CASE  WHEN @SorterValue = 'TypeId' AND @Sort = 0 THEN P.[TypeId] END ASC,
		CASE  WHEN @SorterValue = 'Price' AND @Sort = 0 THEN P.[Price] END ASC,
		CASE  WHEN @SorterValue = 'Ingredients' AND @Sort = 0 THEN P.[Ingredients] END ASC,
		CASE  WHEN @SorterValue = 'Active' AND @Sort = 0 THEN P.[Active] END ASC,
		CASE  WHEN @SorterValue = 'Review' AND @Sort = 0 THEN P.[Review] END ASC,
		CASE  WHEN @SorterValue = 'ApplicationUserId' AND @Sort = 0 THEN P.[ApplicationUserId] END ASC,
		CASE  WHEN @SorterValue = 'UserName' AND @Sort = 0 THEN US.[Name] END ASC,
		CASE  WHEN @SorterValue = 'UserLastName' AND @Sort = 0 THEN US.[LastName] END ASC
    OFFSET @IgnoredReg ROWS
    FETCH NEXT @Reg ROWS ONLY;

    SELECT
        COUNT(1) AS TotalRegistros
    FROM
        dbo.Products AS P
    INNER JOIN
        [dbo].[AspNetUsers] AS US ON US.[Id] = P.[ApplicationUserId]
	LEFT JOIN
		[dbo].[ProductFeaturesDetails] AS PFD ON PFD.[ProductId] = P.[ProductId]
	LEFT JOIN
		[dbo].[ProductFeatures] AS PF ON PF.[ProductFeatureId] = PFD.[ProductFeaturesId] 
	LEFT JOIN
		[dbo].[ProductCategorys] AS PCAT ON PCAT.[ProductId] = P.[ProductId]
	LEFT JOIN
		[dbo].[Categories] AS CAT ON CAT.[CategoryId] = PCAT.[CategoryId]
     WHERE 
		  (CASE
				WHEN @Filter = 'PriceRange' THEN CASE WHEN (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) THEN 1 ELSE 0 END

				--WHEN @Filter = 'Category' THEN CASE WHEN EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') THEN 1 ELSE 0 END

				WHEN @Filter = 'Review' THEN CASE WHEN P.[Review] >= @Review THEN 1 ELSE 0 END

				--WHEN @Filter = 'FilterValue' THEN CASE WHEN (dbo.ValidateFilterValue(P.[ProductId],P.[Name],P.[Description],P.[Image],P.[TypeId],P.[Price],P.[Ingredients],P.[Active],P.[Review],P.[ApplicationUserId],US.[Name],US.[LastName],
				--	STRING_AGG(CAT.[Name],','),
				--	STRING_AGG(PF.[Features],','),@FilterValue) = 1) THEN 1 ELSE 0 END

				--WHEN @Filter = 'PriceRange,Category' THEN CASE WHEN (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') THEN 1 ELSE 0 END

				--WHEN @Filter = 'Review,Category' THEN CASE WHEN EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') AND P.[Review] >= @Review THEN 1 ELSE 0 END

				WHEN @Filter = 'PriceRange,Review' THEN CASE WHEN (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND P.[Review] >= @Review THEN 1 ELSE 0 END

				--WHEN @Filter = 'PriceRange,FilterValue' THEN CASE WHEN (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND (dbo.ValidateFilterValue(P.[ProductId],P.[Name],P.[Description],P.[Image],P.[TypeId],P.[Price],P.[Ingredients],P.[Active],P.[Review],P.[ApplicationUserId],US.[Name],US.[LastName],
				--	STRING_AGG(CAT.[Name],','),
				--	STRING_AGG(PF.[Features],','),@FilterValue) = 1) THEN 1 ELSE 0 END
				--WHEN @Filter = 'Category,FilterValue' THEN CASE WHEN EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') AND (dbo.ValidateFilterValue(P.[ProductId],P.[Name],P.[Description],P.[Image],P.[TypeId],P.[Price],P.[Ingredients],P.[Active],P.[Review],P.[ApplicationUserId],US.[Name],US.[LastName],
					--STRING_AGG(CAT.[Name],','),
					--STRING_AGG(PF.[Features],','),@FilterValue) = 1) THEN 1 ELSE 0 END

				--WHEN @Filter = 'Review,FilterValue' THEN CASE WHEN P.[Review] >= @Review AND (dbo.ValidateFilterValue(P.[ProductId],P.[Name],P.[Description],P.[Image],P.[TypeId],P.[Price],P.[Ingredients],P.[Active],P.[Review],P.[ApplicationUserId],US.[Name],US.[LastName],
				--	STRING_AGG(CAT.[Name],','),
				--	STRING_AGG(PF.[Features],','),@FilterValue) = 1) THEN 1 ELSE 0 END

				--WHEN @Filter = 'PriceRange,Category,Review' THEN CASE WHEN P.[Review] >= @Review AND (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') THEN 1 ELSE 0 END

				--WHEN @Filter = 'PriceRange,Category,FilterValue' THEN CASE WHEN P.[Review] >= @Review AND (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') THEN 1 ELSE 0 END

				WHEN @Filter = 'PriceRange,Review,FilterValue' THEN CASE WHEN P.[Review] >= @Review AND (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') THEN 1 ELSE 0 END

				--WHEN @Filter = 'Category,Review,FilterValue' THEN CASE WHEN P.[Review] >= @Review AND (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') THEN 1 ELSE 0 END

				WHEN @Filter = 'All' THEN CASE WHEN (
				--dbo.ValidateFilterValue(P.[ProductId],P.[Name],P.[Description],P.[Image],P.[TypeId],P.[Price],P.[Ingredients],P.[Active],P.[Review],P.[ApplicationUserId],US.[Name],US.[LastName],
				--	STRING_AGG(CAT.[Name],','),
				--	STRING_AGG(PF.[Features],','),@FilterValue) = 1)	AND 
					(P.[Price] >= @PriceMin AND P.[Price] <= @PriceMax)
					--AND EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%')
					AND P.[Review] >= @Review)
								THEN 1 ELSE 0 END
				ELSE	1
			END
		) = 1
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
        US.[LastName];
END;
