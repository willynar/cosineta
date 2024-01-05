USE [trabajo]
GO
/****** Object:  StoredProcedure [dbo].[paginated_products]    Script Date: 5/01/2024 9:50:51 a. m. ******/
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
        P.[ChefId],
        P.[Price],
        P.[Serving],
        P.[Ingredients],
        P.[Active] AS ProductActive,
        P.[CategoryId],
		P.[Review],
        CAT.[Name] AS CategoryName,
        CH.[Name] AS ChefName,
        CH.[Phone] AS ChefPhone,
        CH.[Cellphone] AS ChefCellphone,
        CH.[Email] AS ChefEmail,
        CH.[Image] AS ChefImage,
        CH.[Cover] AS ChefCover,
        CH.[Gender] AS ChefGender,
        CH.[Nationality] AS ChefNationality,
        CH.[Country] AS ChefCountry,
        CH.[Department] AS ChefDepartment,
        CH.[Status] AS ChefStatus,
        CH.[Certified] AS ChefCertified,
        CH.[CertifiedMessage] AS ChefCertifiedMessage,
        CH.[Description] AS ChefDescription,
        CH.[Active] AS ChefActive,
        CAT.[Image] AS CategoryImage,
        CAT.[Active] AS CategoryActive
    FROM
        dbo.Products AS P
    LEFT JOIN
        dbo.Chefs AS CH ON P.ChefId = CH.ChefId
    LEFT JOIN
        dbo.Categories AS CAT ON P.CategoryId = CAT.CategoryId
    WHERE 
		  (CASE
				WHEN @Filter = 'PriceRange' THEN CASE WHEN (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) THEN 1 ELSE 0 END

				WHEN @Filter = 'Category' THEN CASE WHEN EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') THEN 1 ELSE 0 END

				WHEN @Filter = 'Review' THEN CASE WHEN P.[Review] >= @Review THEN 1 ELSE 0 END

				WHEN @Filter = 'FilterValue' THEN CASE WHEN ( dbo.ValidateFilterValue(P.[ProductId],P.[Name],P.[Description],P.[Image],P.[ChefId],P.[Price],P.[Serving],P.[Ingredients],P.[Active],P.[CategoryId],P.[Review],CAT.[Name],CH.[Name],CH.[Phone],CH.[Cellphone],CH.[Email],CH.[Image],CH.[Cover],CH.[Gender],CH.[Nationality],CH.[Country],CH.[Department],CH.[Status],CH.[Certified],CH.[CertifiedMessage],CH.[Description],CH.[Active],CAT.[Image],CAT.[Active],@FilterValue) = 1) THEN 1 ELSE 0 END

				WHEN @Filter = 'PriceRange,Category' THEN CASE WHEN (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') THEN 1 ELSE 0 END

				WHEN @Filter = 'Review,Category' THEN CASE WHEN EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') AND P.[Review] >= @Review THEN 1 ELSE 0 END

				WHEN @Filter = 'PriceRange,Review' THEN CASE WHEN (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND P.[Review] >= @Review THEN 1 ELSE 0 END

				WHEN @Filter = 'PriceRange,FilterValue' THEN CASE WHEN (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND ( dbo.ValidateFilterValue(P.[ProductId],P.[Name],P.[Description],P.[Image],P.[ChefId],P.[Price],P.[Serving],P.[Ingredients],P.[Active],P.[CategoryId],P.[Review],CAT.[Name],CH.[Name],CH.[Phone],CH.[Cellphone],CH.[Email],CH.[Image],CH.[Cover],CH.[Gender],CH.[Nationality],CH.[Country],CH.[Department],CH.[Status],CH.[Certified],CH.[CertifiedMessage],CH.[Description],CH.[Active],CAT.[Image],CAT.[Active],@FilterValue) = 1) THEN 1 ELSE 0 END
				WHEN @Filter = 'Category,FilterValue' THEN CASE WHEN EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') AND ( dbo.ValidateFilterValue(P.[ProductId],P.[Name],P.[Description],P.[Image],P.[ChefId],P.[Price],P.[Serving],P.[Ingredients],P.[Active],P.[CategoryId],P.[Review],CAT.[Name],CH.[Name],CH.[Phone],CH.[Cellphone],CH.[Email],CH.[Image],CH.[Cover],CH.[Gender],CH.[Nationality],CH.[Country],CH.[Department],CH.[Status],CH.[Certified],CH.[CertifiedMessage],CH.[Description],CH.[Active],CAT.[Image],CAT.[Active],@FilterValue) = 1) THEN 1 ELSE 0 END

				WHEN @Filter = 'Review,FilterValue' THEN CASE WHEN P.[Review] >= @Review AND ( dbo.ValidateFilterValue(P.[ProductId],P.[Name],P.[Description],P.[Image],P.[ChefId],P.[Price],P.[Serving],P.[Ingredients],P.[Active],P.[CategoryId],P.[Review],CAT.[Name],CH.[Name],CH.[Phone],CH.[Cellphone],CH.[Email],CH.[Image],CH.[Cover],CH.[Gender],CH.[Nationality],CH.[Country],CH.[Department],CH.[Status],CH.[Certified],CH.[CertifiedMessage],CH.[Description],CH.[Active],CAT.[Image],CAT.[Active],@FilterValue) = 1) THEN 1 ELSE 0 END

				WHEN @Filter = 'PriceRange,Category,Review' THEN CASE WHEN P.[Review] >= @Review AND (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') THEN 1 ELSE 0 END

				WHEN @Filter = 'PriceRange,Category,FilterValue' THEN CASE WHEN P.[Review] >= @Review AND (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') THEN 1 ELSE 0 END

				WHEN @Filter = 'PriceRange,Review,FilterValue' THEN CASE WHEN P.[Review] >= @Review AND (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') THEN 1 ELSE 0 END

				WHEN @Filter = 'Category,Review,FilterValue' THEN CASE WHEN P.[Review] >= @Review AND (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') THEN 1 ELSE 0 END

				WHEN @Filter = 'All' THEN CASE WHEN ( dbo.ValidateFilterValue(P.[ProductId],P.[Name],P.[Description],P.[Image],P.[ChefId],P.[Price],P.[Serving],P.[Ingredients],P.[Active],P.[CategoryId],P.[Review],CAT.[Name],CH.[Name],CH.[Phone],CH.[Cellphone],CH.[Email],CH.[Image],CH.[Cover],CH.[Gender],CH.[Nationality],CH.[Country],CH.[Department],CH.[Status],CH.[Certified],CH.[CertifiedMessage],CH.[Description],CH.[Active],CAT.[Image],CAT.[Active],@FilterValue) = 1)	AND (P.[Price] >= @PriceMin AND P.[Price] <= @PriceMax)AND EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') AND P.[Review] >= @Review
								THEN 1 ELSE 0 END
				ELSE	1
			END
		) = 1
    ORDER BY
		CASE  WHEN @SorterValue = 'ProductId' AND @Sort = 0 THEN P.[ProductId] END ASC,
		CASE  WHEN @SorterValue = 'ProductName' AND @Sort = 0 THEN P.[Name] END ASC,
		CASE  WHEN @SorterValue = 'ProductDescription' AND @Sort = 0 THEN P.[Description] END ASC,
		CASE  WHEN @SorterValue = 'ProductImage' AND @Sort = 0 THEN P.[Image] END ASC,
		CASE  WHEN @SorterValue = 'ChefId' AND @Sort = 0 THEN P.[ChefId] END ASC,
		CASE  WHEN @SorterValue = 'Price' AND @Sort = 0 THEN P.[Price] END ASC,
		CASE  WHEN @SorterValue = 'Serving' AND @Sort = 0 THEN P.[Serving] END ASC,
		CASE  WHEN @SorterValue = 'Ingredients' AND @Sort = 0 THEN P.[Ingredients] END ASC,
		CASE  WHEN @SorterValue = 'ProductActive' AND @Sort = 0 THEN P.[Active] END ASC,
		CASE  WHEN @SorterValue = 'CategoryId' AND @Sort = 0 THEN P.[CategoryId] END ASC,
		CASE  WHEN @SorterValue = 'Review' AND @Sort = 0 THEN P.[Review] END ASC,
		CASE  WHEN @SorterValue = 'CategoryName' AND @Sort = 0 THEN CAT.[Name] END ASC,
		CASE  WHEN @SorterValue = 'ChefName' AND @Sort = 0 THEN CH.[Name] END ASC,
		CASE  WHEN @SorterValue = 'ChefPhone' AND @Sort = 0 THEN CH.[Phone] END ASC,
		CASE  WHEN @SorterValue = 'ChefCellphone' AND @Sort = 0 THEN CH.[Cellphone] END ASC,
		CASE  WHEN @SorterValue = 'ChefEmail' AND @Sort = 0 THEN CH.[Email] END ASC,
		CASE  WHEN @SorterValue = 'ChefImage' AND @Sort = 0 THEN CH.[Image] END ASC,
		CASE  WHEN @SorterValue = 'ChefCover' AND @Sort = 0 THEN CH.[Cover] END ASC,
		CASE  WHEN @SorterValue = 'ChefGender' AND @Sort = 0 THEN CH.[Gender] END ASC,
		CASE  WHEN @SorterValue = 'ChefNationality' AND @Sort = 0 THEN CH.[Nationality] END ASC,
		CASE  WHEN @SorterValue = 'ChefCountry' AND @Sort = 0 THEN CH.[Country] END ASC,
		CASE  WHEN @SorterValue = 'ChefDepartment' AND @Sort = 0 THEN CH.[Department] END ASC,
		CASE  WHEN @SorterValue = 'ChefStatus' AND @Sort = 0 THEN CH.[Status] END ASC,
		CASE  WHEN @SorterValue = 'ChefCertified' AND @Sort = 0 THEN CH.[Certified] END ASC,
		CASE  WHEN @SorterValue = 'ChefCertifiedMessage' AND @Sort = 0 THEN CH.[CertifiedMessage] END ASC,
		CASE  WHEN @SorterValue = 'ChefDescription' AND @Sort = 0 THEN CH.[Description] END ASC,
		CASE  WHEN @SorterValue = 'ChefActive' AND @Sort = 0 THEN CH.[Active] END ASC,
		CASE  WHEN @SorterValue = 'CategoryImage' AND @Sort = 0 THEN CAT.[Image] END ASC,
		CASE  WHEN @SorterValue = 'CategoryActive' AND @Sort = 0 THEN CAT.[Active] END ASC
    OFFSET @IgnoredReg ROWS
    FETCH NEXT @Reg ROWS ONLY;

    SELECT
        COUNT(1) AS TotalRegistros
    FROM
        dbo.Products AS P
    LEFT JOIN
        dbo.Chefs AS CH ON P.ChefId = CH.ChefId
    LEFT JOIN
        dbo.Categories AS CAT ON P.CategoryId = CAT.CategoryId
     WHERE 
		  (CASE
				WHEN @Filter = 'PriceRange' THEN CASE WHEN (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) THEN 1 ELSE 0 END

				WHEN @Filter = 'Category' THEN CASE WHEN EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') THEN 1 ELSE 0 END

				WHEN @Filter = 'Review' THEN CASE WHEN P.[Review] >= @Review THEN 1 ELSE 0 END

				WHEN @Filter = 'FilterValue' THEN CASE WHEN ( dbo.ValidateFilterValue(P.[ProductId],P.[Name],P.[Description],P.[Image],P.[ChefId],P.[Price],P.[Serving],P.[Ingredients],P.[Active],P.[CategoryId],P.[Review],CAT.[Name],CH.[Name],CH.[Phone],CH.[Cellphone],CH.[Email],CH.[Image],CH.[Cover],CH.[Gender],CH.[Nationality],CH.[Country],CH.[Department],CH.[Status],CH.[Certified],CH.[CertifiedMessage],CH.[Description],CH.[Active],CAT.[Image],CAT.[Active],@FilterValue) = 1) THEN 1 ELSE 0 END

				WHEN @Filter = 'PriceRange,Category' THEN CASE WHEN (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') THEN 1 ELSE 0 END

				WHEN @Filter = 'Review,Category' THEN CASE WHEN EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') AND P.[Review] >= @Review THEN 1 ELSE 0 END

				WHEN @Filter = 'PriceRange,Review' THEN CASE WHEN (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND P.[Review] >= @Review THEN 1 ELSE 0 END

				WHEN @Filter = 'PriceRange,FilterValue' THEN CASE WHEN (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND ( dbo.ValidateFilterValue(P.[ProductId],P.[Name],P.[Description],P.[Image],P.[ChefId],P.[Price],P.[Serving],P.[Ingredients],P.[Active],P.[CategoryId],P.[Review],CAT.[Name],CH.[Name],CH.[Phone],CH.[Cellphone],CH.[Email],CH.[Image],CH.[Cover],CH.[Gender],CH.[Nationality],CH.[Country],CH.[Department],CH.[Status],CH.[Certified],CH.[CertifiedMessage],CH.[Description],CH.[Active],CAT.[Image],CAT.[Active],@FilterValue) = 1) THEN 1 ELSE 0 END
				WHEN @Filter = 'Category,FilterValue' THEN CASE WHEN EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') AND ( dbo.ValidateFilterValue(P.[ProductId],P.[Name],P.[Description],P.[Image],P.[ChefId],P.[Price],P.[Serving],P.[Ingredients],P.[Active],P.[CategoryId],P.[Review],CAT.[Name],CH.[Name],CH.[Phone],CH.[Cellphone],CH.[Email],CH.[Image],CH.[Cover],CH.[Gender],CH.[Nationality],CH.[Country],CH.[Department],CH.[Status],CH.[Certified],CH.[CertifiedMessage],CH.[Description],CH.[Active],CAT.[Image],CAT.[Active],@FilterValue) = 1) THEN 1 ELSE 0 END

				WHEN @Filter = 'Review,FilterValue' THEN CASE WHEN P.[Review] >= @Review AND ( dbo.ValidateFilterValue(P.[ProductId],P.[Name],P.[Description],P.[Image],P.[ChefId],P.[Price],P.[Serving],P.[Ingredients],P.[Active],P.[CategoryId],P.[Review],CAT.[Name],CH.[Name],CH.[Phone],CH.[Cellphone],CH.[Email],CH.[Image],CH.[Cover],CH.[Gender],CH.[Nationality],CH.[Country],CH.[Department],CH.[Status],CH.[Certified],CH.[CertifiedMessage],CH.[Description],CH.[Active],CAT.[Image],CAT.[Active],@FilterValue) = 1) THEN 1 ELSE 0 END

				WHEN @Filter = 'PriceRange,Category,Review' THEN CASE WHEN P.[Review] >= @Review AND (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') THEN 1 ELSE 0 END

				WHEN @Filter = 'PriceRange,Category,FilterValue' THEN CASE WHEN P.[Review] >= @Review AND (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') THEN 1 ELSE 0 END

				WHEN @Filter = 'PriceRange,Review,FilterValue' THEN CASE WHEN P.[Review] >= @Review AND (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') THEN 1 ELSE 0 END

				WHEN @Filter = 'Category,Review,FilterValue' THEN CASE WHEN P.[Review] >= @Review AND (P.[Price] >= @PriceMin  AND P.[Price] <= @PriceMax) AND EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') THEN 1 ELSE 0 END

				WHEN @Filter = 'All' THEN CASE WHEN ( dbo.ValidateFilterValue(P.[ProductId],P.[Name],P.[Description],P.[Image],P.[ChefId],P.[Price],P.[Serving],P.[Ingredients],P.[Active],P.[CategoryId],P.[Review],CAT.[Name],CH.[Name],CH.[Phone],CH.[Cellphone],CH.[Email],CH.[Image],CH.[Cover],CH.[Gender],CH.[Nationality],CH.[Country],CH.[Department],CH.[Status],CH.[Certified],CH.[CertifiedMessage],CH.[Description],CH.[Active],CAT.[Image],CAT.[Active],@FilterValue) = 1)	AND (P.[Price] >= @PriceMin AND P.[Price] <= @PriceMax)AND EXISTS (SELECT 1 FROM STRING_SPLIT(@CategoryValue, ',') AS SearchValue WHERE CAT.[Name] LIKE '%' + SearchValue.value + '%') AND P.[Review] >= @Review
								THEN 1 ELSE 0 END
				ELSE	1
			END
		) = 1;
END;
