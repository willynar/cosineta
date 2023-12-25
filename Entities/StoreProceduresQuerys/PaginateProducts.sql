
CREATE PROCEDURE [dbo].[paginated_products]
(
    @Page INT,
    @Reg INT,
    @Filter NVARCHAR(MAX),
    @Sort NVARCHAR(MAX),
    @Sorter INT
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
        P.[ProductId] LIKE '%' + @Filter + '%'
        OR P.[Name] LIKE '%' + @Filter + '%'
        OR P.[Description] LIKE '%' + @Filter + '%'
        OR P.[Image] LIKE '%' + @Filter + '%'
        OR P.[ChefId] LIKE '%' + @Filter + '%'
        OR P.[Price] LIKE '%' + @Filter + '%'
        OR P.[Serving] LIKE '%' + @Filter + '%'
        OR P.[Ingredients] LIKE '%' + @Filter + '%'
        OR P.[Active] LIKE '%' + @Filter + '%'
        OR P.[CategoryId] LIKE '%' + @Filter + '%'
        OR CAT.[Name] LIKE '%' + @Filter + '%'
        OR CH.[Name] LIKE '%' + @Filter + '%'
        OR CH.[Phone] LIKE '%' + @Filter + '%'
        OR CH.[Cellphone] LIKE '%' + @Filter + '%'
        OR CH.[Email] LIKE '%' + @Filter + '%'
        OR CH.[Image] LIKE '%' + @Filter + '%'
        OR CH.[Cover] LIKE '%' + @Filter + '%'
        OR CH.[Gender] LIKE '%' + @Filter + '%'
        OR CH.[Nationality] LIKE '%' + @Filter + '%'
        OR CH.[Country] LIKE '%' + @Filter + '%'
        OR CH.[Department] LIKE '%' + @Filter + '%'
        OR CH.[Status] LIKE '%' + @Filter + '%'
        OR CH.[Certified] LIKE '%' + @Filter + '%'
        OR CH.[CertifiedMessage] LIKE '%' + @Filter + '%'
        OR CH.[Description] LIKE '%' + @Filter + '%'
        OR CH.[Active] LIKE '%' + @Filter + '%'
        OR CAT.[Image] LIKE '%' + @Filter + '%'
        OR CAT.[Active] LIKE '%' + @Filter + '%'
    ORDER BY
		CASE  WHEN @Sort = 'ProductId' AND @Sorter = 0 THEN P.[ProductId] END ASC,
		CASE  WHEN @Sort = 'ProductName' AND @Sorter = 0 THEN P.[Name] END ASC,
		CASE  WHEN @Sort = 'ProductDescription' AND @Sorter = 0 THEN P.[Description] END ASC,
		CASE  WHEN @Sort = 'ProductImage' AND @Sorter = 0 THEN P.[Image] END ASC,
		CASE  WHEN @Sort = 'ChefId' AND @Sorter = 0 THEN P.[ChefId] END ASC,
		CASE  WHEN @Sort = 'Price' AND @Sorter = 0 THEN P.[Price] END ASC,
		CASE  WHEN @Sort = 'Serving' AND @Sorter = 0 THEN P.[Serving] END ASC,
		CASE  WHEN @Sort = 'Ingredients' AND @Sorter = 0 THEN P.[Ingredients] END ASC,
		CASE  WHEN @Sort = 'ProductActive' AND @Sorter = 0 THEN P.[Active] END ASC,
		CASE  WHEN @Sort = 'CategoryId' AND @Sorter = 0 THEN P.[CategoryId] END ASC,
		CASE  WHEN @Sort = 'CategoryName' AND @Sorter = 0 THEN CAT.[Name] END ASC,
		CASE  WHEN @Sort = 'ChefName' AND @Sorter = 0 THEN CH.[Name] END ASC,
		CASE  WHEN @Sort = 'ChefPhone' AND @Sorter = 0 THEN CH.[Phone] END ASC,
		CASE  WHEN @Sort = 'ChefCellphone' AND @Sorter = 0 THEN CH.[Cellphone] END ASC,
		CASE  WHEN @Sort = 'ChefEmail' AND @Sorter = 0 THEN CH.[Email] END ASC,
		CASE  WHEN @Sort = 'ChefImage' AND @Sorter = 0 THEN CH.[Image] END ASC,
		CASE  WHEN @Sort = 'ChefCover' AND @Sorter = 0 THEN CH.[Cover] END ASC,
		CASE  WHEN @Sort = 'ChefGender' AND @Sorter = 0 THEN CH.[Gender] END ASC,
		CASE  WHEN @Sort = 'ChefNationality' AND @Sorter = 0 THEN CH.[Nationality] END ASC,
		CASE  WHEN @Sort = 'ChefCountry' AND @Sorter = 0 THEN CH.[Country] END ASC,
		CASE  WHEN @Sort = 'ChefDepartment' AND @Sorter = 0 THEN CH.[Department] END ASC,
		CASE  WHEN @Sort = 'ChefStatus' AND @Sorter = 0 THEN CH.[Status] END ASC,
		CASE  WHEN @Sort = 'ChefCertified' AND @Sorter = 0 THEN CH.[Certified] END ASC,
		CASE  WHEN @Sort = 'ChefCertifiedMessage' AND @Sorter = 0 THEN CH.[CertifiedMessage] END ASC,
		CASE  WHEN @Sort = 'ChefDescription' AND @Sorter = 0 THEN CH.[Description] END ASC,
		CASE  WHEN @Sort = 'ChefActive' AND @Sorter = 0 THEN CH.[Active] END ASC,
		CASE  WHEN @Sort = 'CategoryImage' AND @Sorter = 0 THEN CAT.[Image] END ASC,
		CASE  WHEN @Sort = 'CategoryActive' AND @Sorter = 0 THEN CAT.[Active] END ASC
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
        P.[ProductId] LIKE '%' + @Filter + '%'
        OR P.[Name] LIKE '%' + @Filter + '%'
        OR P.[Description] LIKE '%' + @Filter + '%'
        OR P.[Image] LIKE '%' + @Filter + '%'
        OR P.[ChefId] LIKE '%' + @Filter + '%'
        OR P.[Price] LIKE '%' + @Filter + '%'
        OR P.[Serving] LIKE '%' + @Filter + '%'
        OR P.[Ingredients] LIKE '%' + @Filter + '%'
        OR P.[Active] LIKE '%' + @Filter + '%'
        OR P.[CategoryId] LIKE '%' + @Filter + '%'
        OR CAT.[Name] LIKE '%' + @Filter + '%'
        OR CH.[Name] LIKE '%' + @Filter + '%'
        OR CH.[Phone] LIKE '%' + @Filter + '%'
        OR CH.[Cellphone] LIKE '%' + @Filter + '%'
        OR CH.[Email] LIKE '%' + @Filter + '%'
        OR CH.[Image] LIKE '%' + @Filter + '%'
        OR CH.[Cover] LIKE '%' + @Filter + '%'
        OR CH.[Gender] LIKE '%' + @Filter + '%'
        OR CH.[Nationality] LIKE '%' + @Filter + '%'
        OR CH.[Country] LIKE '%' + @Filter + '%'
        OR CH.[Department] LIKE '%' + @Filter + '%'
        OR CH.[Status] LIKE '%' + @Filter + '%'
        OR CH.[Certified] LIKE '%' + @Filter + '%'
        OR CH.[CertifiedMessage] LIKE '%' + @Filter + '%'
        OR CH.[Description] LIKE '%' + @Filter + '%'
        OR CH.[Active] LIKE '%' + @Filter + '%'
        OR CAT.[Image] LIKE '%' + @Filter + '%'
        OR CAT.[Active] LIKE '%' + @Filter + '%';
END;
