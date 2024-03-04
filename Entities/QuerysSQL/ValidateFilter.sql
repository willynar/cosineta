/****** Object:  UserDefinedFunction [dbo].[ValidateFilter]    Script Date: 4/03/2024 1:50:00 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER FUNCTION [dbo].[ValidateFilter]
(
	@ProductIdFromTBL INT NULL,
    @ProductNameFromTBL NVARCHAR(MAX) NULL,
    @ProductDescriptionFromTBL NVARCHAR(MAX) NULL,
    @ProductImageFromTBL NVARCHAR(MAX) NULL,
    @TypeIdFromTBL INT NULL,
    @PriceFromTBL DECIMAL(18,2) NULL,
    @IngredientsFromTBL NVARCHAR(MAX) NULL,
    @ProductActiveFromTBL BIT NULL,
	@ReviewFromTBL DECIMAL(18,2) NULL,
    @ApplicationUserIdFromTBL NVARCHAR(MAX) NULL,
    @UserNameFromTBL NVARCHAR(MAX) NULL,
    @UserLastNameFromTBL NVARCHAR(MAX) NULL,
    @SPCategoryIdFromTBL INT NULL,
    @SPFeactureIdFromTBL INT NULL,
    @StarTimeFromTBL DATETIME NULL,
    @EndTimeFromTBL DATETIME NULL,
    @ServingFromTBL INT NULL,
    @FilterValue NVARCHAR(MAX) NULL,
    @PriceMin DECIMAL(18,2) NULL,
    @PriceMax DECIMAL(18,2) NULL,
    @Review DECIMAL(18,2) NULL,
    @StarTime DATETIME NULL,
    @EndTime DATETIME NULL,
    @Serving INT NULL
)
RETURNS BIT
AS
BEGIN
	DECLARE @Result BIT;

		SET @Result = (CASE 
						WHEN 
							   (CASE
									WHEN @FilterValue LIKE '%PriceRange%' THEN (CASE WHEN (@PriceFromTBL >= @PriceMin  AND @PriceFromTBL <= @PriceMax)  THEN '1' ELSE '0' END) + ','
									ELSE ''
								END  +
								CASE
									WHEN @FilterValue LIKE '%Review%' THEN (CASE WHEN  @Review >= @ReviewFromTBL  THEN '1' ELSE '0' END) + ','
									ELSE ''
								END +
								CASE
									WHEN @FilterValue LIKE '%Category%' THEN (CASE WHEN  @SPCategoryIdFromTBL IS NOT NULL  THEN '1' ELSE '0' END) + ','
									ELSE ''
								END +
								CASE
									WHEN @FilterValue LIKE '%Feature%' THEN (CASE WHEN  @SPFeactureIdFromTBL IS NOT NULL  THEN '1' ELSE '0' END) + ','
									ELSE ''
								END +
								CASE
									WHEN @FilterValue LIKE '%FilterValue%' THEN (CASE WHEN  (dbo.ValidateFilterValue(@ProductIdFromTBL,@ProductNameFromTBL,@ProductDescriptionFromTBL,@ProductNameFromTBL,@TypeIdFromTBL,@PriceFromTBL,@IngredientsFromTBL,@ProductActiveFromTBL,@ReviewFromTBL,@ApplicationUserIdFromTBL,@UserNameFromTBL,@UserLastNameFromTBL,@FilterValue) = 1)  THEN '1' ELSE '0' END) + ','
									ELSE ''
								END +
								CASE
									WHEN @FilterValue LIKE '%Time%' THEN (CASE WHEN  (@EndTimeFromTBL >= @StarTime  AND @StarTimeFromTBL <= @EndTime)  THEN '1' ELSE '0' END) + ','
									ELSE ''
								END +
								CASE
									WHEN @FilterValue LIKE '%Serving%' THEN (CASE WHEN  @Serving >= @ServingFromTBL  THEN '1' ELSE '0' END) + ','
									ELSE ''
								END 
								+
								CASE
									WHEN @FilterValue IS NOT NULL THEN (CASE WHEN LTRIM(RTRIM(@FilterValue)) = ''  THEN '1' ELSE '0' END) + ','
									ELSE ''
								END 
							) LIKE '%0%' 
							THEN 0
						ELSE 
							1
					END);
    RETURN @Result;
END;
